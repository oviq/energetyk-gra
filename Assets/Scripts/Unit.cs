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

        InvokeRepeating("IsTargetAlive", 0f, 0.1f);

        currentCooldown = 0f;
    }

    void FixedUpdate()
    {
        // sprawdzanie czy jednostka zyje
        if (isAlive)
        {
            if (hp <= 0)
            {
                isAlive = false;
            }
        }

        // ogarnianie cooldowna
        if (currentCooldown > 0)
        {
            currentCooldown -= Time.fixedDeltaTime;
        }
    }

    // mozna zadawac obrazenia
    public void TakeDamage(float damage)
    {
        if (isAlive)
        {
            hp -= damage;

            if (healthBar != null)
            {
                healthBar.SetHealth(hp);
            }

            HelperFunctions.LogMessage(this.name + " otrzymuje " + damage + " obrazen");
        }
    }

    // wykonuje currentAttack na currentTargecie oraz daje atakowi dostep do systemu animacji
    public void Attack(Animator animator)
    {
        if (isAlive)
        {
            if (currentCooldown <= 0)
            {
                if (currentTarget != null && currentTarget.isAlive)
                {
                    currentAttack.Action(currentTarget, animator);
                    currentCooldown = currentAttack.GetCooldown();
                    HelperFunctions.LogMessage(this.name + " atakuje " + currentTarget.name + " uzywajac " + currentAttack.name);
                }
            }
        }
    }

    // sprawdza czy target jest zywy
    private void IsTargetAlive()
    {
        if (currentTarget != null )
        {
            if (!currentTarget.isAlive)
            {
                currentTarget = null;
            }
        }
    }
}
