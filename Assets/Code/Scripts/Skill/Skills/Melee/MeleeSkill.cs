using System.Collections;
using System.Collections.Generic;
using Unity.FPS.Game;
using UnityEngine;

public class MeleeSkill : Skill
{
    public Transform Pivot;
    public float Damage = .0f;
    public ProjectileBase MeleeAttack;

    public MeleeSkill() : base("Melee", .3f, .1f)
    {
    }

    public override void Activate()
    {
        base.Activate();

        if (Pivot != null)
        {
            Instantiate(MeleeAttack, Pivot.transform);
        }

    }
}