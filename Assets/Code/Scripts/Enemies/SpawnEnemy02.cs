using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Unity.FPS.Gameplay;

public class SpawnEnemy02 : MonoBehaviour
{
    //Which enemy to spawn
    public GameObject enemyPrefab2;
    GameObject spawn;

    //Objective script
    private ObjectiveKillEnemies objectiveKillEnemies;

    //How many kill until next wave
    public int Limits = 4;

    //list of spawn points
    public List<Transform> pointsLevel1;
    public List<Transform> pointsLevel2;
    public List<Transform> pointsLevel3;






    void Start()
    {
        spawn = enemyPrefab2;
        objectiveKillEnemies = FindObjectOfType<ObjectiveKillEnemies>();
        if (objectiveKillEnemies == null)
        {
            Debug.LogError("Could not find ObjectiveKillEnemies component!");
        }
        objectiveKillEnemies.killedTrigger = 0;
        SpawnEnemies02();
        
    }

    void Update()
    {
        if (objectiveKillEnemies != null && objectiveKillEnemies.killedTrigger >= Limits && objectiveKillEnemies.CurrentWave < objectiveKillEnemies.Waves)
        {
            SpawnEnemies02();
            
        }
    }

    void SpawnEnemies02()
    {
        switch (objectiveKillEnemies.level)
        {
            case 1:
                for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < pointsLevel1.Count; j++)
                    {
                        Instantiate(spawn, pointsLevel1[j].position, transform.rotation);
                    }
                }
                break;
            case 2:
                for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < pointsLevel2.Count; j++)
                    {
                        Instantiate(spawn, pointsLevel2[j].position, transform.rotation);
                    }
                }
                break;
            case 3:
                for (int i = 0; i < objectiveKillEnemies.numEnemiesToSpawn; i++)
                {
                    for (int j = 0; j < pointsLevel3.Count; j++)
                    {
                        Instantiate(spawn, pointsLevel3[j].position, transform.rotation);
                    }
                }
                break;
            default:
                Debug.LogError("Invalid level specified!");
                break;


                
        }
        Debug.Log("Spawning " + spawn.name);
        objectiveKillEnemies.killedTrigger = 0;
        
    }

}