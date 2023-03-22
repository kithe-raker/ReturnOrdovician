using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.FPS.Gameplay;

public class SpawnEnemy : MonoBehaviour
{
    //Which enemy to spawn
    public GameObject enemyPrefab;

    //list of spawn points
    public List<Transform> points;

    //Number of enemies to spawn
    public int numEnemiesToSpawn = 1;

    //Objective script
    private ObjectiveKillEnemies objectiveKillEnemies;

    //How many kill until next wave
    public int Limits = 4;

    //When to stop/ after how many kill
    public int End = 10;

    void Start()
    {
        objectiveKillEnemies = FindObjectOfType<ObjectiveKillEnemies>();
        if (objectiveKillEnemies == null)
        {
            Debug.LogError("Could not find ObjectiveKillEnemies component!");
        }
        SpawnEnemies();
        objectiveKillEnemies.killedTest=0;
    }

    void Update()
    {
        if (objectiveKillEnemies != null && objectiveKillEnemies.killedTest >= Limits && objectiveKillEnemies.m_KillTotal < End)
        {
            SpawnEnemies();
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < numEnemiesToSpawn; i++)
        {
            for (int j = 0; j < points.Count; j++)
            {
            Instantiate(enemyPrefab, points[j].position, transform.rotation);
            
            }
            
        }
        objectiveKillEnemies.killedTest = 0;
    }
}