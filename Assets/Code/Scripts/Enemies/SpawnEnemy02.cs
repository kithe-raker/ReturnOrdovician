using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.FPS.Gameplay;

public class SpawnEnemy02 : MonoBehaviour
{
    //Which enemy to spawn
    public GameObject enemyPrefab1;
    GameObject spawn;

    //Objective script
    private ObjectiveKillEnemies objectiveKillEnemies;

    //How many kill until next wave
    public int Limits = 4;

    //list of spawn points
    public List<Transform> pointsLevel1;
    public List<Transform> pointsLevel2;
    public List<Transform> pointsLevel3;

    //Number of enemies to spwan
    public int numEnemiesToSpawn = 1;

    //How many waves?
    public int Waves = 3;

    //Current wave
    public int CurrentWave = 0;



    void Start()
    {
        spawn = enemyPrefab1;

        objectiveKillEnemies = FindObjectOfType<ObjectiveKillEnemies>();
        if (objectiveKillEnemies == null)
        {
            Debug.LogError("Could not find ObjectiveKillEnemies component!");
        }
        objectiveKillEnemies.killedTriggerMantis = 0;
        //SpawnEnemies02();
        
    }

    void Update()
    {
        if (objectiveKillEnemies != null && objectiveKillEnemies.killedTriggerMantis >= Limits && CurrentWave < Waves)
        {
            SpawnEnemies02();
            
        }
    }

    void SpawnEnemies02()
    {
        switch (objectiveKillEnemies.level)
        {
            case 1:
                for (int i = 0; i < numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < pointsLevel1.Count; j++)
                    {
                        Instantiate(spawn, pointsLevel1[j].position, transform.rotation);
                    }
                }
                CurrentWave++;
                break;
            case 2:
                for (int i = 0; i < numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < pointsLevel2.Count; j++)
                    {
                        Instantiate(spawn, pointsLevel2[j].position, transform.rotation);
                    }
                }
                CurrentWave++;
                break;
            case 3:
                for (int i = 0; i < numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < pointsLevel3.Count; j++)
                    {
                        Instantiate(spawn, pointsLevel3[j].position, transform.rotation);
                    }
                }
                CurrentWave++;
                break;
            default:
                Debug.LogError("Invalid level specified!");
                break;
        }
        Debug.Log("Spawning " + spawn.name);
        objectiveKillEnemies.killedTriggerMantis = 0;
        
    }

}