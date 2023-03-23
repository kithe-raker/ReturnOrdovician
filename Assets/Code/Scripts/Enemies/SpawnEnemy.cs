using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.FPS.Gameplay;

public class SpawnEnemy : MonoBehaviour
{
    //Which enemy to spawn
    public GameObject enemyPrefab;

    //Objective script
    private ObjectiveKillEnemies objectiveKillEnemies;

    //How many kill until next wave
    public int Limits = 4;

    

    //Current wave
    public int CurrentWave = 0;

    

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
        if (objectiveKillEnemies != null && objectiveKillEnemies.killedTest >= Limits && CurrentWave < objectiveKillEnemies.Waves)
        {
            SpawnEnemies();
            
        }
    }

    void SpawnEnemies()
    {
        for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
        {
            for (int j = 0; j < objectiveKillEnemies.points.Count; j++)
            {
            Instantiate(enemyPrefab, objectiveKillEnemies.points[j].position, transform.rotation);
            
            }
            
        }
        objectiveKillEnemies.killedTest = 0;
        CurrentWave++;
    }
}