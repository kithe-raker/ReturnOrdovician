using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanelController : MonoBehaviour
{
    public InteractableObject interaction;

    // Start is called before the first frame update
    void Start()
    {
        if (interaction != null)
        {
            interaction.OnInteract += OnInteracted;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnDestroy()
    {
        if (interaction != null)
        {
            interaction.OnInteract -= OnInteracted;
        }
    }

    void OnInteracted()
    {
        Debug.Log("hello");
    }
}
