using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


public class LevelOverallController : MonoBehaviour
{
    public List<SlideDoorController> doors;


    // Start is called before the first frame update
    void Start()
    {
        SetDoorStatus(0, true);
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetDoorStatus(int doorIndex, bool open)
    {
        if (doorIndex < doors.Count)
        {
            doors[doorIndex].SetDoor(open);
        }
    }

}
