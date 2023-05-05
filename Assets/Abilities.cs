using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    public Image abilityImg1;
    public float cooldown1 = 5;
    bool isCooldown = false;
    public KeyCode ability1;

    // Start is called before the first frame update
    void Start()
    {
        abilityImg1.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        AbilityMelee();
    }
    void AbilityMelee()
    {
        if(Input.GetKey(ability1)&& !isCooldown)
        {
            isCooldown = true;
            abilityImg1.fillAmount = 1;
        }

        if (isCooldown)
        {
            abilityImg1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImg1.fillAmount <= 0)
            {
                abilityImg1.fillAmount = 0;
                isCooldown = false;
            }
        }
    }
}
