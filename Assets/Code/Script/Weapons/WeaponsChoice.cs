using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponsChoice : MonoBehaviour
{


    public List<GameObject> item;
    int numOfItems;
    public List<Transform> point;
    int numOfPoint;


    // Start is called before the first frame update 
    void Start()
    {
        numOfItems = item.Count;
        numOfPoint = point.Count;
    }
    public void spawnItem(){
        int randomNum=0;
        int saveNum=99999;
        for(int i = 0;i<numOfPoint;i++){
            randomNum = Random.Range(0,numOfItems);
            while(randomNum == saveNum){
                randomNum = Random.Range(0,numOfItems);
            }
            Instantiate(item[randomNum], point[i].position, transform.rotation);
            saveNum = randomNum;
        }
    }
     int once = 1;
    // Update is called once per frame
    void Update()
    {
        if(once == 1){
            spawnItem();
            once = 2;
        }
    }
}
