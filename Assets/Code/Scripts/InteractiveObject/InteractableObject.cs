using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public delegate void InteractionEvent();

public class InteractableObject : MonoBehaviour
{
    public event InteractionEvent OnInteract;

    public void InvokeOnInteract()
    {
        Debug.Log("Start");
        OnInteract();
    }

}
