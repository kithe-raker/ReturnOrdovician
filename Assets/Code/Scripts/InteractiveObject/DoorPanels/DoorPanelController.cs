using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate bool PanelInteractEvent();

public class DoorPanelController : MonoBehaviour
{
    public InteractableObject interaction;
    public SlideDoorController slideDoorController;

    public PanelInteractEvent onPanelInteract;

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
        bool open = onPanelInteract?.Invoke() ?? false;
        slideDoorController.SetDoor(open);
    }
}
