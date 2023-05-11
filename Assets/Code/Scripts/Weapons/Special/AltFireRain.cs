using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

namespace Unity.FPS.Game
{
    public class AltFireRain : MonoBehaviour
    {
        public WeaponController wc;         //wc is stand for Water Closet aka bathroom not Weapon Controller... wait.... the opposite!
        public ProjectileBase ProjectilePrefabAlt;
        ProjectileBase ProjectilePrefabOriginal;
        string displayCrimeCommit;
        string displayOriginalAmount;

        public TextMeshProUGUI NumberUI;

        float ReloadSpeedYnOriginal;
        float BulletSpreadAngleOriginal;
        int BulletsPerShotOriginal;

       // public float AltReloadSpeedYn = 8f;    //         HELLO, I COMMENT THIS IN CASE I MAKE OTHER ALT THAT NEED TO INCREASE RELOAD TIME SO I CAN HAVE EXAMPLE
        public float AltBulletSpreadAngle = 40f;
        public int AltBulletsPerShot = 96;
        public int WarCrimeClusterBombAmount = 3;
        int saveBombAmount;
        public int AmmoUse = 1;
        //int workOnce = 0;
        void Start()
        {    
            ProjectilePrefabOriginal = wc.ProjectilePrefab;
             BulletSpreadAngleOriginal = wc.BulletSpreadAngle;
             BulletsPerShotOriginal = wc.BulletsPerShot;
            saveBombAmount = WarCrimeClusterBombAmount;
            displayOriginalAmount = saveBombAmount.ToString();
        }
        void Update()
        {
            displayCrimeCommit = (saveBombAmount-WarCrimeClusterBombAmount).ToString();
            if(WarCrimeClusterBombAmount!=0){
            NumberUI.text = "Committing war crime: " + displayCrimeCommit+"/"+displayOriginalAmount;
            }
            else{
               NumberUI.text = ""; 
            }
            if (Input.GetKeyDown("mouse 1") && wc.IsWeaponActive && wc.reloadStart == false && WarCrimeClusterBombAmount>0)
            {
                if (wc.m_CurrentAmmo >= AmmoUse)//wc.MagSizeYn
                {
                    wc.ProjectilePrefab = ProjectilePrefabAlt;
                    wc.BulletSpreadAngle = AltBulletSpreadAngle;
                    wc.BulletsPerShot = AltBulletsPerShot;

                    if(wc.TryShoot()==true){
                    wc.m_CurrentAmmo = wc.m_CurrentAmmo-(AmmoUse-1);
                    WarCrimeClusterBombAmount = WarCrimeClusterBombAmount -1;
                    }
                     wc.ProjectilePrefab = ProjectilePrefabOriginal;
                    wc.BulletSpreadAngle = BulletSpreadAngleOriginal;
                    wc.BulletsPerShot = BulletsPerShotOriginal;
                }
            }
        }
    }
}


