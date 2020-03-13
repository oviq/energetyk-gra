using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// placeholderowy atak do zadawania obrazen, na razie zupelnie bez animacji
// mozna traktowac jako wzor
public class XKill : Attack
{
    // to jest funkcja do atakowania celu bez korzystania z animacji
    public override void Action(Unit target)
    {
        // cel dostaje 10 obrazen
        target.TakeDamege(10);
    }

    // to jest funkcja do atakowania celu z wykorzystaniem animacji
    public override void Action(Unit target, Animator animator)
    {
        // tu sie nic nie dzieje
    }
}
