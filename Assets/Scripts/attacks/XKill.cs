using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// placeholderowy atak do zabijania wszystkiego na hita
public class XKill : Attack
{
    public override void Action(Unit target)
    {
        target.TakeDamege(10);
    }

    public override void Action(Unit target, Animator animator)
    {

    }
}
