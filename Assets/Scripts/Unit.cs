using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// klasa generalnego uzytku do przechowywania stanu zdrowia dowolnej jednostki
// mozna do niej podlaczyc pasek zdrowia, ale dziala nawet bez niego

public class Unit : MonoBehaviour
{
    // statystyki jednostki i czy nalezy do gracza
    private float hp;
    public float max_hp;
    public bool isAlive;
    public bool canBeControlledByPlayer;

    // dostep do klasy paska zycia
    public HealthBar healthBar;

    // dostepne ataki jednostki i aktualnie wybrany atak, oraz aktualny cel
    public List<Attack> attacks;
    public Attack currentAttack;
    public Unit currentTarget;

    void Start()
    {
        hp = max_hp;
        if (healthBar != null)
        {
            healthBar.SetMaxHealth(max_hp);
            healthBar.SetHealth(hp);
        }
        isAlive = true;
    }

    void FixedUpdate()
    {
        if (isAlive)
        {
            if (hp <= 0)
            {
                isAlive = false;
            }
        }

    }

    // mozna zadawac obrazenia
    public void TakeDamege(float damage)
    {
        if (isAlive)
        {
            hp -= damage;

            if (healthBar != null)
            {
                healthBar.SetHealth(hp);
            }
        }
    }

    // wykonuje currentAttack na currentTargecie
    public void Attack()
    {
        currentAttack.Action(currentTarget);
    }

    // wykonuje currentAttack na currentTargecie oraz daje atakowi dostep do systemu animacji
    public void Attack(Animator animator)
    {
        currentAttack.Action(currentTarget, animator);
    }
}
