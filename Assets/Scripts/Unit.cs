using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public float hp;
    public float max_hp;
    public bool isAlive;

    public GameObject tlusta_chmura;

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

    public void Attack()
    {
        if (isAlive)
        {
            if (attack_counter > cooldown)
            {
                Instantiate(tlusta_chmura, transform.position, Quaternion.identity);
                attack_counter = 0;
            }
        }
    }
}
