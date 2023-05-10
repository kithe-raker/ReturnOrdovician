using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Gameplay;
using UnityEngine;

public class HideArm : MonoBehaviour
{
    public bool isNotCooldown = true;
    public GameObject arm;
    private PlayerWeaponsManager weapon;
    IEnumerator Hide()
    {
        
        yield return new WaitForSeconds(1f);
        arm.SetActive(true);
        isNotCooldown = true;
    }
    // Start is called before the first frame update
    void Start()
    {
        weapon = GetComponent<PlayerWeaponsManager>();
        arm.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        weapon.IsMelee = !isNotCooldown;
        if (Input.GetKey(KeyCode.F)&&isNotCooldown) 
        {
            isNotCooldown= false;
            arm.SetActive(false);
            StartCoroutine(Hide());
        }
    }
   
}
