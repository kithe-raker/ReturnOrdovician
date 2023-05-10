using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class StartTelepot : MonoBehaviour
{
    public GameObject Player;
    public InteractableObject interaction;
    public GameObject TPpoint;
    void Awake()
    {
        if (interaction != null)
        {
            interaction.OnInteract += OnInteracted;
        }
    }
    // Start is called before the first frame update
    private void OnDestroy()
    {
        if (interaction != null)
        {
            interaction.OnInteract -= OnInteracted;
        }
    }

    void OnInteracted()
    {
        Player.SetActive(false);
        Player.transform.SetPositionAndRotation(TPpoint.transform.position, TPpoint.transform.rotation);
        Player.SetActive(true);

        Health playerHealth = Player.GetComponent<Health>();
        if (playerHealth)
        {
            playerHealth.Heal(999);
        }
    }
}
