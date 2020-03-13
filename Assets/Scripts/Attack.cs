using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Abstrakcyjna klasa zeby mozna bylo trzymac ataki w jednej tablicy/liscie/hashsecie
public abstract class Attack : MonoBehaviour
{
    public abstract void Action(Unit target);

    public abstract void Action(Unit target, Animator animator);
}