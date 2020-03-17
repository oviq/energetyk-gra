using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// placeholderowy atak do zadawania obrazen, na razie zupelnie bez animacji
// mozna traktowac jako wzor
public class XKill : Attack
{
    // to jest funkcja do atakowania celu z wykorzystaniem animacji
    public override void Action(Unit target, Animator animator)
    {
        target.TakeDamege(5f);
    }

    public override float GetRange()
    {
        return 1000f;
    }

    public override float GetCooldown()
    {
        return 2f;
    }
}
