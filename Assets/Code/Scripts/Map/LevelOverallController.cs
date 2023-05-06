using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


public class LevelOverallController : MonoBehaviour
{
    public List<LevelRoomObject> roomObjects;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void SetEnterLevelDoorStatus(int levelIndex, bool open)
    {
        if (levelIndex < roomObjects.Count)
        {
            roomObjects[levelIndex].SetEnterDoors(open);
        }
    }


    public void SetExitLevelDoorStatus(int levelIndex, bool open)
    {
        if (levelIndex < roomObjects.Count)
        {
            roomObjects[levelIndex].SetExitDoors(open);
        }
    }

}
