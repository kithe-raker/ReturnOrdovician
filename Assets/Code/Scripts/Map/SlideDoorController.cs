using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;

public class SlideDoorController : MonoBehaviour
{
    public GameObject left;
    public GameObject right;
    public bool isOpen = false;
    public float currentRange = 0;
    public float openRange = 2;


    private const float _openDoorSpeed = 2f;


    // Start is called before the first frame update
    void Start()
    {
        if (!left || !right)
        {
            Debug.LogError("No Left/Right slide door provided");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if ((isOpen && currentRange < openRange) || (!isOpen && currentRange > 0))
        {
            float direction = isOpen ? 1 : -1;
            float distance = direction * _openDoorSpeed * Time.deltaTime;

            left.transform.Translate(distance * Vector3.right);
            right.transform.Translate(distance * Vector3.left);
            currentRange += distance;
        }
    }

    public void SetDoor(bool open)
    {
        isOpen = open;
    }

}
