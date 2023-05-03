using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


[System.Serializable]
public class DoorStruct
{
    public GameObject left;
    public GameObject right;
    public bool isOpen;
    public float currentRange;
    public float openRange;
}

public class LevelOverallController : MonoBehaviour
{
    public List<DoorStruct> doors;
    private const float openDoorSpeed = .5f;


    // Start is called before the first frame update
    void Start()
    {
        OpenDoor(0);
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDoor();
    }

    public void OpenDoor(int doorIndex)
    {
        if (doorIndex < doors.Count)
        {
            DoorStruct door = doors[doorIndex];
            door.isOpen = true;
            doors[doorIndex] = door;
        }
    }

    void UpdateDoor()
    {
        for (int i = 0; i < doors.Count; i++)
        {
            DoorStruct door = doors[i];
            if (door.isOpen && door.currentRange < door.openRange)
            {
                door.left.transform.Translate(openDoorSpeed * Time.deltaTime * Vector3.right);
                door.right.transform.Translate(openDoorSpeed * Time.deltaTime * Vector3.left);
                door.currentRange += 5 * Time.deltaTime; ;

                doors[i] = door;
            }
        }
    }
}
