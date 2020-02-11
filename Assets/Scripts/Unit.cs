using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour
{

    public float hp;
    public float max_hp;

    public GameObject tlusta_chmura;

    public float countdown;
    [SerializeField] private float attack_counter;

    // Start is called before the first frame update
    void Start()
    {
        attack_counter = 0;
        hp = max_hp;
    }

    // Update is called once per frame
    void Update()
    {
        attack_counter++;
    }

    public void TakeDamege(float damage)
    {
        hp -= damage;
    }

    public void Attack()
    {
        if (attack_counter > countdown)
        {
            //Instantiate(tlusta_chmura, transform);
            attack_counter = 0; 
        }
        
    }

}
