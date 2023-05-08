using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : MonoBehaviour
{
    public Skill skill;
    public float cooldownTime;
    float activeTime;
    public KeyCode key;

    enum AbilityState
    {
        ready,
        active,
        cooldown
    }
    AbilityState state = AbilityState.ready;

    
    void Update()
    {
        
        switch (state)
        {
            case AbilityState.ready:
                if (Input.GetKey(key))
                {
                    skill.Activate();
                    state = AbilityState.active;
                    activeTime = skill.activeTime;
                }
                break;
            case AbilityState.active:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    skill.Deactivate();
                    state = AbilityState.cooldown;
                    cooldownTime = skill.cooldownTime;
                }
                break;
            case AbilityState.cooldown:
                if (cooldownTime > 0)
                {
                    cooldownTime -= Time.deltaTime;
                }
                else
                {
                    state = AbilityState.ready;
                }
                break;
        }


    }
}
