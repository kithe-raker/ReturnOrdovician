using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorPanelController : MonoBehaviour
{
    public InteractableObject interaction;
    public SlideDoorController slideDoorController;

    // Start is called before the first frame update
    void Start()
    {
        if (interaction != null && slideDoorController != null)
        {
            interaction.OnInteract += OnInteracted;
        }
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
        slideDoorController.SetDoor(true);
    }
}
