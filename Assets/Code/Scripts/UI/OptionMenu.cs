using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class OptionMenu : MonoBehaviour
{
    public GameObject Option;
    public GameObject control;
    public AudioMixer Audio;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape)|| Input.GetKey(KeyCode.Tab))
        {
            Option.SetActive(false);
        }
    }

    public void GameControlOpen()
    {
        control.SetActive(true);
    }
    public void GameControlClose()
    {
        control.SetActive(false);
    }
    public void OnShadowsChanged(bool newValue)
    {
        QualitySettings.shadows = newValue ? ShadowQuality.All : ShadowQuality.Disable;
    }
    public void SetBGMValue(float sliderValue)
    {
        Audio.SetFloat("BGMVolume",Mathf.Log10((float)sliderValue)*20);
    }
    public void CloseOption()
    {
        Option.SetActive(false);
    }
}
