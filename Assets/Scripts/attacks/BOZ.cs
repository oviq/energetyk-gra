using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BOZ : Attack
{
    public override float GetCooldown()
    {
        return 1f;
    }

    public override float GetRange()
    {
        return 1.5f;
    }

    public override void Action(Unit target, Animator animator)
    {
        target.TakeDamage(10f);
    }
}
