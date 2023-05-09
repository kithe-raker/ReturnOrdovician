using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level2WeaponsChoice : MonoBehaviour                //put prefab at 5.615347   -0.7528152       185.91
{


    public List<GameObject> item;
    int numOfItems;
    public List<Transform> point;
    int numOfPoint;

    GameObject Weapon1;
    GameObject Weapon2;

    // Start is called before the first frame update 
    void Start()
    {
        numOfItems = item.Count;
        numOfPoint = point.Count;
    }
    public void spawnItem(){
        for(int i = 0;i<numOfPoint;i++){
            Instantiate(item[i], point[i].position, transform.rotation);
        }
        Weapon1 = GameObject.Find(item[0].name+"(Clone)");
        Weapon2 = GameObject.Find(item[1].name+"(Clone)");
    }

     int once = 1;
     
    void Update()
    {
        if(once == 1){
            spawnItem();
            once = 2;
        }

        if((Weapon1==null||Weapon2==null)&&once==2){
            Destroy(Weapon1);
            Destroy(Weapon2);
            once = 3;
        }
     
    }
}
