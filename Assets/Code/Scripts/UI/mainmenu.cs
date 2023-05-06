using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour
{
    public GameObject option;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public void StartButton()
    {
        SceneManager.LoadScene("Level1");
    }
    public void quitgame()
    {
        Application.Quit();
    }
    public void optionBut()
    {
        option.SetActive(true);
    }
}
