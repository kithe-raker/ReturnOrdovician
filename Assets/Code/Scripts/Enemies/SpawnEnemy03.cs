using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.FPS.Gameplay;

public class SpawnEnemy03 : MonoBehaviour
{
    //Which enemy to spawn
    GameObject spawn;
    public GameObject enemyPrefab3;

    //Objective script
    private ObjectiveKillEnemies objectiveKillEnemies;

    //How many kill until next wave
    public int Limits = 4;

    

    

    

    void Start()
    {
        spawn = enemyPrefab3;

        objectiveKillEnemies = FindObjectOfType<ObjectiveKillEnemies>();
        if (objectiveKillEnemies == null)
        {
            Debug.LogError("Could not find ObjectiveKillEnemies component!");
        }
        objectiveKillEnemies.killedTrigger = 0;
        SpawnEnemies();
    }

    void Update()
    {
        if (objectiveKillEnemies != null && objectiveKillEnemies.killedTrigger >= Limits && objectiveKillEnemies.CurrentWave < objectiveKillEnemies.Waves)
        {
            SpawnEnemies();
            
        }
    }

    void SpawnEnemies()
    {
        switch (objectiveKillEnemies.level)
        {
            case 1:
                for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < objectiveKillEnemies.pointsLevel1.Count; j++)
                    {
                        Instantiate(spawn, objectiveKillEnemies.pointsLevel1[j].position, transform.rotation);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < objectiveKillEnemies.pointsLevel2.Count; j++)
                    {
                        Instantiate(spawn, objectiveKillEnemies.pointsLevel2[j].position, transform.rotation);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < objectiveKillEnemies.pointsLevel3.Count; j++)
                    {
                        Instantiate(spawn, objectiveKillEnemies.pointsLevel3[j].position, transform.rotation);
                    }
                }
                break;
            default:
                Debug.LogError("Invalid level specified!");
                break;
        }
        Debug.Log("Spawning " + spawn.name);
        objectiveKillEnemies.killedTrigger = 0;
        objectiveKillEnemies.level++;
    }

}