using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// ten caly skrypt nie dziala trzeba go naprawic

public class Chmura : MonoBehaviour
{
    public float countdown;
    [SerializeField] private float attack_counter;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        attack_counter++;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (attack_counter > countdown)
        {
            col.GetComponent<Unit>().TakeDamege(5);
            attack_counter = 0;
        }   
    }
}
