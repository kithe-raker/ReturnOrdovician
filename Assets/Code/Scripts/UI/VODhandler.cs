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
    
    void Start()
    {
        
    }

    
    // Update is called once per frame
    void Update()
    {
        StartCoroutine(Ending());
    }
    IEnumerator Ending()
    {
        yield return new WaitForSeconds(1);
        if (!VOD.isPlaying)
        {
            Debug.Log("end");
            SceneManager.LoadScene(GameStart);
        }
    }
    public void isPress()
    {
        Debug.Log("boop");
        VOD.Stop();
        SceneManager.LoadScene(GameStart);
    }
}
