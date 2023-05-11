using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.ProBuilder.Shapes;


public class LevelOverallController : MonoBehaviour
{
    public List<LevelRoomObject> roomObjects;


    // Start is called before the first frame update
    void Start()
    {
        EventManager.AddListener<LevelCompletedEvent>(OnLevelCompleted);
    }


    private void OnDestroy()
    {
        EventManager.RemoveListener<LevelCompletedEvent>(OnLevelCompleted);
    }

    void OnLevelCompleted(LevelCompletedEvent evt)
    {
        SetExitLevelDoorStatus(evt.completedLevel - 1, true);
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
