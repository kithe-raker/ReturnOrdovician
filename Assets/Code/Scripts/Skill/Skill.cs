using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skill : MonoBehaviour
{
    public string skillName = "";
    public float cooldownTime = .0f;
    public float activeTime = .0f;

    public Skill(string name, float cooldown, float active)
    {
        this.skillName = name;
        this.cooldownTime = cooldown;
        this.activeTime = active;
    }

    public virtual void Activate() { }
    public virtual void Deactivate() { }
}
