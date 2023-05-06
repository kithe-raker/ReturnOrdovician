using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelRoomObject : MonoBehaviour
{
    public List<SlideDoorController> enterDoors;
    public List<SlideDoorController> exitDoors;

    public void SetEnterDoors(bool open)
    {
        foreach (SlideDoorController door in enterDoors)
        {
            door.SetDoor(open);
        }
    }
    public void SetExitDoors(bool open)
    {
        foreach (SlideDoorController door in exitDoors)
        {
            door.SetDoor(open);
        }
    }


}
