using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Unity.FPS.Game
{
    public class AltFire : MonoBehaviour
    {
        public WeaponController wc;         //wc is stand for Water Closet aka bathroom not Weapon Controller... wait.... the opposite!
        public ProjectileBase ProjectilePrefabAlt;
        ProjectileBase ProjectilePrefabOriginal;
        void Start()
        {
            print("start func in pistol alt work");
            ProjectilePrefabOriginal = wc.ProjectilePrefab;
        }
        void Update()
        {
            if (Input.GetKeyDown("mouse 1") && wc.IsWeaponActive && wc.reloadStart == false)
            {
                if (wc.m_CurrentAmmo >= 16)
                {
                    wc.ProjectilePrefab = ProjectilePrefabAlt;
                    wc.TryShoot();
                    wc.m_CurrentAmmo = 0;
                    wc.ProjectilePrefab = ProjectilePrefabOriginal;
                }
            }
        }
    }
}
