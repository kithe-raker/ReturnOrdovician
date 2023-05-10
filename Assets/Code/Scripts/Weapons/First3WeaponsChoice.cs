using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class First3WeaponsChoice : MonoBehaviour
{

    
    public List<GameObject> item;
    int numOfItems;
    public List<Transform> point;
    int numOfPoint;
    public GameObject UI;

    GameObject CompactSmg;
    GameObject Pistol;
    GameObject Revolver;

    // Start is called before the first frame update 
    void Start()
    {
        UI.SetActive(true);
        numOfItems = item.Count;
        numOfPoint = point.Count;
    }
    public void spawnItem(){
        for(int i = 0;i<numOfPoint;i++){
            Instantiate(item[i], point[i].position, transform.rotation);
        }
        CompactSmg = GameObject.Find("Pickup_CompactPlasmaSMG(Clone)");
        Pistol = GameObject.Find("Pickup_PlasmaPistol(Clone)");
        Revolver = GameObject.Find("Pickup_PlasmaRevolver(Clone)");
    }

     int once = 1;
     
    void Update()
    {
        if(once == 1){
            spawnItem();
            once = 2;
        }

        if((CompactSmg==null||Pistol==null||Revolver==null)&&once==2){
            Destroy(CompactSmg);
            Destroy(Pistol);
            Destroy(Revolver);
            once = 3;
            UI.SetActive(true);
        }
     
    }
}
