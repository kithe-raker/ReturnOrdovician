using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level1WeaponsChoice : MonoBehaviour
{
//place this prefab at the middle of door of level1 to level2. warning there are 3 doors //-15.94   -0.683    35.183

    public List<GameObject> item;
    int numOfItems;
    public List<Transform> point;
    int numOfPoint;

    // GameObject Rifle;
    // GameObject Shotgun;
    // GameObject Smg;

    GameObject[] FindWeapon = new GameObject[6];

    // Start is called before the first frame update 
    void Start()
    {
        numOfItems = item.Count;
        numOfPoint = point.Count;
    }
    public void spawnItem(){
    
        Instantiate(item[0], point[0].position, transform.rotation);
        Instantiate(item[0], point[3].position, transform.rotation);
        Instantiate(item[1], point[1].position, transform.rotation);
        Instantiate(item[1], point[4].position, transform.rotation);
        Instantiate(item[2], point[2].position, transform.rotation);
        Instantiate(item[2], point[5].position, transform.rotation);
        
        // CompactSmg = GameObject.Find("Pickup_CompactPlasmaSMG(Clone)");
        // Pistol = GameObject.Find("Pickup_PlasmaPistol(Clone)");
        // Revolver = GameObject.Find("Pickup_PlasmaRevolver(Clone)");

        FindWeapon[0] = GameObject.Find("Pickup_IonAssaultRifle(Clone)");
        FindWeapon[0].name = "Pickup_IonAssaultRifle(Clone)0";
        FindWeapon[1] = GameObject.Find("Pickup_IonAssaultRifle(Clone)");

        FindWeapon[2] = GameObject.Find("Pickup_PlasmaticShotgun(Clone)");
        FindWeapon[2].name = "Pickup_PlasmaticShotgun(Clone)0";
        FindWeapon[3] = GameObject.Find("Pickup_PlasmaticShotgun(Clone)");

        FindWeapon[4] = GameObject.Find("Pickup_PlasmaticSMG(Clone)");
        FindWeapon[4].name = "Pickup_PlasmaticSMG(Clone)0";
        FindWeapon[5] = GameObject.Find("Pickup_PlasmaticSMG(Clone)");
    }

     int once = 1;
     
    void Update()
    {
        if(once == 1){
            spawnItem();
            once = 2;
        }

        if((FindWeapon[0]==null||FindWeapon[1]==null||FindWeapon[2]==null||FindWeapon[3]==null||FindWeapon[4]==null||FindWeapon[5]==null)&&once==2){
            for(int i = 0;i<6;i++){
                Destroy(FindWeapon[i]);
            }
            once = 3;
        }
    }
}
