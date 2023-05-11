using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
{
    public string SceneName = "";
    public void LoadTargetScene()
    {
        Time.timeScale = 1f;
        Debug.Log(SceneName);
        SceneManager.LoadScene(SceneName);
    }
}