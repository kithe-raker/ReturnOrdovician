using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class VODhandler : MonoBehaviour
{
    // Start is called before the first frame update
    public VideoPlayer VOD;
    public string GameStart = "";
    bool button = false;
    void Start()
    {
        
        
    }

    
    // Update is called once per frame
    void Update()
    {
        Invoke("Ending", 1f);
    }
    public void Ending()
    {
        if (!VOD.isPlaying || button)
        {
            Debug.Log("end");
            SceneManager.LoadScene(GameStart);
        }
    }
    public void isPress()
    {
        button = true;
    }
}
