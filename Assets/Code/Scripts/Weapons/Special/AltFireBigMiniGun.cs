using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
    
    public class AltFireBigMiniGun : MonoBehaviour
    {
        public WeaponController wc;         //wc is stand for Water Closet aka bathroom not Weapon Controller... wait.... the opposite!
        public float altFireRate;
        public float altBulletSpread;
        float fireRateSave;
        float spreadSave;
        void Start()
        {
            fireRateSave = wc.FireRateYn;
            spreadSave = wc.BulletSpreadAngle;
        }
        void Update()
        {
            if (Input.GetKey("mouse 1") && wc.IsWeaponActive && wc.reloadStart == false && Input.GetKey("mouse 0") == false)
            {
                wc.DelayBetweenShots = 1/altFireRate;
                wc.BulletSpreadAngle = altBulletSpread;
                if (wc.m_CurrentAmmo != 0)
                {
                    wc.TryShoot();
                }

            }
            else{
                wc.DelayBetweenShots = 1/fireRateSave;
                wc.BulletSpreadAngle = spreadSave;
            }
        }
    }
}

//wc.DelayBetweenShots;
//DelayBetweenShots = 1/FireRateYn; 
//wc.float BulletSpreadAngle;