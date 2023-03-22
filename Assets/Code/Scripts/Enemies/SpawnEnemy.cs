using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.FPS.Gameplay;

public class SpawnEnemy : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> points;
    public int numEnemiesToSpawn = 1;
    private ObjectiveKillEnemies objectiveKillEnemies;
    public int Limits = 4;

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
        if (objectiveKillEnemies != null && objectiveKillEnemies.killedTest >= Limits && objectiveKillEnemies.m_KillTotal < 8)
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