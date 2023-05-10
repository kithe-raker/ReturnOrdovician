using UnityEngine;
using UnityEngine.Audio;
using Unity.FPS.UI;

public class Sound : MonoBehaviour
{
    public AudioMixer Audio;
    float Aval;
    public InGameMenuManager menu;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        menu.TrueVol = Aval;
    }
    public void SetBGMValue(float sliderValue)
    {
        Aval = sliderValue;
        Audio.SetFloat("MasterVolume", Mathf.Log10((float)sliderValue) * 20);
    }
}
