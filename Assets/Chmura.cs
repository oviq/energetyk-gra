using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ten caly skrypt nie dziala trzeba go naprawic

public class Chmura : MonoBehaviour
{
    public float cooldown;
    private float attack_counter;

    public int damage;
    public float lifetime;

    public List<Unit> targets;

    void Start()
    {
        Destroy(gameObject, lifetime);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (targets.Count > 0)
        {
            // zadaje obrazenia wszystkim celom co <countdown> czasu
            attack_counter += Time.fixedDeltaTime;

            if (attack_counter > cooldown)
            {
                foreach (Unit x in targets)
                {
                    x.TakeDamege(damage);
                }

                attack_counter = 0;
            }
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        targets.Add(col.GetComponent<Unit>());
    }

    void OnTriggerExit2D(Collider2D col)
    {
        targets.Remove(col.GetComponent<Unit>());
    }
}
