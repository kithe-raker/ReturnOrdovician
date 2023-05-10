using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public AudioMixer Audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void SetBGMValue(float sliderValue)
    {
        Audio.SetFloat("MasterVolume", Mathf.Log10((float)sliderValue) * 20);
    }
}
