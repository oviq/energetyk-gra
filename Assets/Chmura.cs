using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ten caly skrypt nie dziala trzeba go naprawic

public class Chmura : MonoBehaviour
{
    public float countdown;
    public int damage;
    private float attack_counter;

    public List<Unit> targets;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (targets.Count > 0)
        {
            // zadaje obrazenia wszystkim celom co <countdown> czasu
            attack_counter++;

            if (attack_counter > countdown)
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
