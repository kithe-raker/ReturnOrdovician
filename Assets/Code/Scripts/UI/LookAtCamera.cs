using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCamera : MonoBehaviour
{
    private void Start()
    {
        // Get the current local scale
        Vector3 localScale = transform.localScale;

        // Flip the local scale horizontally
        localScale.x *= -1;

        // Set the new local scale
        transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Camera.main != null)
        {

            transform.LookAt(Camera.main.transform);
        }
    }
}
