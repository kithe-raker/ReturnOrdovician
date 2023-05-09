using Unity.FPS.Game;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class LoadSceneButton : MonoBehaviour
    {
        public string SceneName = "";


        public void LoadTargetScene()
        {
            SceneManager.LoadScene(SceneName);
        Debug.Log(SceneName);
        }

    }