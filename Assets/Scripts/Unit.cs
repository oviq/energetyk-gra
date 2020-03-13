using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// klasa generalnego uzytku do przechowywania stanu zdrowia dowolnej jednostki
// mozna do niej podlaczyc pasek zdrowia, ale dziala nawet bez niego

public class Unit : MonoBehaviour
{

    private float hp;
    public float max_hp;
    public bool isAlive;

    public HealthBar healthBar;

    public float cooldown;

    // Start is called before the first frame update
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

    // Update is called once per frame
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
}
