using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterLevelPanelScript : MonoBehaviour
{
    public SpawnEnemy01 point1;
    public SpawnEnemy02 point2;
    public SpawnEnemy03 point3;
    public int NextRoomTotalWave1 = -1;
    public int NextRoomTotalWave2 = -1;
    public int NextRoomTotalWave3 = -1;
    public LevelRoomObject previouseRoom;

    private DoorPanelController panelController;

    // Start is called before the first frame update
    void Start()
    {
        panelController = GetComponent<DoorPanelController>();

        if (panelController != null)
        {
            panelController.onPanelInteract += onPanelInteracted;
        }
    }

    private void OnDestroy()
    {
        if (panelController != null)
        {
            panelController.onPanelInteract -= onPanelInteracted;
        }
    }

    bool onPanelInteracted()
    {
        point1.CurrentWave = 0;
        point2.CurrentWave = 0;
        point3.CurrentWave = 0;
        if (NextRoomTotalWave1 > -1)
        {
            point1.Waves = NextRoomTotalWave1;
        }
        if (NextRoomTotalWave2 > -1)
        {
            point2.Waves = NextRoomTotalWave2;
        }
        if (NextRoomTotalWave3 > -1)
        {
            point3.Waves = NextRoomTotalWave3;
        }
        if (previouseRoom)
        {
            previouseRoom.SetExitDoors(false);
        }
        return true;
    }

}
