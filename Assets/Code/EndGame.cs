using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;


public class EndGame : MonoBehaviour
{
    private ObjectiveKillEnemies Objective;
    public InteractableObject interaction;
    public bool pressAble = false;
    public GameObject button;
    void Start()
    {
        Objective = FindObjectOfType<ObjectiveKillEnemies>();
        if (interaction != null)
        {
            interaction.OnInteract += OnInteracted;
        }
    }

    private void OnDestroy()
    {
        if (interaction != null && pressAble)
        {
            interaction.OnInteract -= OnInteracted;
        }
    }

    void OnInteracted()
    {
        Debug.Log("POI");
        Objective.buttonPressed = true;
    }
    private void Update()
    {
        if (Objective.m_KillTotal >=150)
        {
            pressAble= true;
            button.SetActive(true);
        }
    }
}
