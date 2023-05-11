using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.FPS.Game;
public class LevelRoomObject : MonoBehaviour
{
    public List<SlideDoorController> enterDoors;
    public List<SlideDoorController> exitDoors;
    public AudioClip DoorSound;
    AudioSource DoorAudio;
    public void Awake()
    {
        DoorAudio = gameObject.AddComponent<AudioSource>();
        DoorAudio.clip = DoorSound;
        DoorAudio.outputAudioMixerGroup = AudioUtility.GetAudioGroup(AudioUtility.AudioGroups.WeaponOverheat);
    }
    public void SetEnterDoors(bool open)
    {
        if (!DoorAudio.isPlaying)
        {
            DoorAudio.Play();
        }
        else if (DoorAudio.isPlaying)
        {
            DoorAudio.Stop();
            return;
        }
        foreach (SlideDoorController door in enterDoors)
        {
            door.SetDoor(open);
            
        }
    }
    
    public void SetExitDoors(bool open)
    {
        if (!DoorAudio.isPlaying)
        {
            DoorAudio.Play();
        }
        else if (DoorAudio.isPlaying)
        {
            DoorAudio.Stop();
            return;
        }
        foreach (SlideDoorController door in exitDoors)
        {
            door.SetDoor(open);
        }
    }


}
