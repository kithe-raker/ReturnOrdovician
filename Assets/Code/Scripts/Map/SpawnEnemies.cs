using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour
{
    public GameObject putEnemyPrefabHere;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("g")){
            Instantiate(putEnemyPrefabHere, new Vector3(transform.position.x, transform.position.y, transform.position.z),Quaternion.identity);
        }
    }
}
