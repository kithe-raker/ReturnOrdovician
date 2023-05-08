using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    public float PlayerActiveDistance;

    bool _active = false;

    // Update is called once per frame
    void Update()
    {
        Transform camTransform = Camera.main.transform;
        _active = Physics.Raycast(camTransform.position, camTransform.TransformDirection(Vector3.forward), out RaycastHit hit, PlayerActiveDistance);

        if (Input.GetKeyDown(KeyCode.E) && _active)
        {
            InteractableObject interactObject = hit.transform.GetComponent<InteractableObject>();
            if (interactObject != null)
            {
                interactObject.InvokeOnInteract();
            }
        }
    }
}
