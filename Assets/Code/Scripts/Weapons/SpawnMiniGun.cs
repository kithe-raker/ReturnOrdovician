using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;

public class SpawnMiniGun : MonoBehaviour
{
    
    public InteractableObject interaction;
    public GameObject miniGun;
    public Transform point;

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
        Instantiate(miniGun, point.position, transform.rotation);
    }
}
