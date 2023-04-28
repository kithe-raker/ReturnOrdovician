using Unity.FPS.Game;
using UnityEngine;

namespace Unity.FPS.Gameplay
{
    public class WeaponPickupYesNo : Pickup
    {
        [Tooltip("The prefab for the weapon that will be added to the player on pickup")]
        public WeaponController WeaponPrefab;
        //public WeaponController testRemovePrefab;
        protected override void Start()
        {
            base.Start();

            // Set all children layers to default (to prefent seeing weapons through meshes)
            foreach (Transform t in GetComponentsInChildren<Transform>())
            {
                if (t != transform)
                    t.gameObject.layer = 0;
            }
        }

        protected override void OnPicked(PlayerCharacterController byPlayer)
        {
            PlayerWeaponsManager playerWeaponsManager = byPlayer.GetComponent<PlayerWeaponsManager>();
           
            if (playerWeaponsManager)
            {
                
                //if(playerWeaponsManager.m_WeaponSlots[0]!=null&&playerWeaponsManager.m_WeaponSlots[1]!=null){   //fail cause it detect after pickup
                //haveNullDetect = 0;

               // print("start: " + playerWeaponsManager.haveNullDetect);
                if(playerWeaponsManager.haveNullDetect==0){
                    Instantiate(playerWeaponsManager.spawnWeapons[playerWeaponsManager.m_WeaponSlots[playerWeaponsManager.ActiveWeaponIndex].weaponIdYesno], playerWeaponsManager.weaponSpawnLocation.position, transform.rotation);
                    playerWeaponsManager.RemoveWeapon(playerWeaponsManager.m_WeaponSlots[playerWeaponsManager.ActiveWeaponIndex]);
                }

                if(playerWeaponsManager.m_WeaponSlots[0]!=null&&playerWeaponsManager.m_WeaponSlots[1]!=null){            
                    playerWeaponsManager.haveNullDetect = 0;
                }
                else{
                    playerWeaponsManager.haveNullDetect = 1;
                }  

                //print("lomid: " + playerWeaponsManager.haveNullDetect);

                if (playerWeaponsManager.AddWeapon(WeaponPrefab))
                {

                    if(playerWeaponsManager.m_WeaponSlots[0]==null||playerWeaponsManager.m_WeaponSlots[1]==null){            
                    playerWeaponsManager.haveNullDetect = 1;
                }
                else{
                    playerWeaponsManager.haveNullDetect = 0;
                }  
                //print("output: " + playerWeaponsManager.haveNullDetect);


                    // Handle auto-switching to weapon if no weapons currently
                    if (playerWeaponsManager.GetActiveWeapon() == null)
                    {
                       playerWeaponsManager.SwitchWeapon(true);
                    }
                    PlayPickupFeedback();

                    Destroy(gameObject);
                }
            }
        }
    }
}










////how I find out why logic fail
// if(playerWeaponsManager.m_WeaponSlots[0]==null){
                //     print("weapon 0 null");
                // }
                // if(playerWeaponsManager.m_WeaponSlots[0]!=null){
                //     print("weapon 0 not null");
                // }
                // if(playerWeaponsManager.m_WeaponSlots[1]==null){
                //     print("weapon 1 null");
                // }
                // if(playerWeaponsManager.m_WeaponSlots[1]!=null){
                //     print("weapon 1 not null");
                // }