using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    private float hp;
    public float max_hp;
    public bool isAlive;

    public HealthBar healthBar;

    public float cooldown;
    private float attack_counter;

    private CharacterMovement cm;

    // Start is called before the first frame update
    void Start()
    {
        attack_counter = 0;
        hp = max_hp;
        healthBar.SetMaxHealth(max_hp);
        healthBar.SetHealth(hp);
        isAlive = true;

        cm = gameObject.GetComponent<CharacterMovement>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isAlive)
        {
            attack_counter += Time.fixedDeltaTime;

            if (hp <= 0)
            {
                isAlive = false;
                cm.Die();
            }
        }

    }

    public void TakeDamege(float damage)
    {
        if (isAlive)
        {
            hp -= damage;
            healthBar.SetHealth(hp);
        }
    }
}
