using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using Unity.FPS.Gameplay;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{
    private SkillManager skill;
    private PlayerCharacterControllerDoubleJump control;
    public Image abilityImg1;
    public Image abilityImg2;
    public float cooldown1;
    public float cooldown2;
    int dashamt;
    bool isCooldown1 = false;
    bool isCooldown2 = false;
    public KeyCode ability1;
    public KeyCode ability2;

    // Start is called before the first frame update
    void Start()
    {
        PlayerCharacterControllerDoubleJump playerCharacterController =
                GameObject.FindObjectOfType<PlayerCharacterControllerDoubleJump>();
            DebugUtility.HandleErrorIfNullFindObject<PlayerCharacterControllerDoubleJump, Abilities>(
                playerCharacterController, this);
        skill = playerCharacterController.GetComponent<SkillManager>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterControllerDoubleJump, Abilities>(skill, this,
            playerCharacterController.gameObject);
        control = playerCharacterController.GetComponent<PlayerCharacterControllerDoubleJump>();
        DebugUtility.HandleErrorIfNullGetComponent<PlayerCharacterControllerDoubleJump, Abilities>(skill, this,
            playerCharacterController.gameObject);
        abilityImg1.fillAmount = 0;
        abilityImg2.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        cooldown1 = skill.cooldownTime;
        cooldown2 = control.dashCooldown;
        dashamt = control.dash;
        AbilityMelee();
        AbilityDash();
        if(cooldown1 <= 0)
        {
            cooldown1 = 0;
        }
    }
    public void AbilityMelee()
    {
        if(Input.GetKey(ability1)&& !isCooldown1)
        {
            isCooldown1 = true;
            abilityImg1.fillAmount = 1;
        }

        if (isCooldown1)
        {
            abilityImg1.fillAmount -= 1 / cooldown1 * Time.deltaTime;

            if(abilityImg1.fillAmount <= 0)
            {
                abilityImg1.fillAmount = 0;
                isCooldown1 = false;
            }
        }
    }
    public void AbilityDash()
    {
        if ((Input.GetKey(ability2) && !isCooldown2) && dashamt >=3)
        {
            isCooldown2 = true;
            abilityImg2.fillAmount = 1;
        }

        if (isCooldown2)
        {
            abilityImg2.fillAmount -= 1 / cooldown2 * Time.deltaTime;

            if (abilityImg2.fillAmount <= 0)
            {
                abilityImg2.fillAmount = 0;
                isCooldown2 = false;
            }
        }
    }
}