﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// klasa do kontrolowania ruchu i animacji dowolnej postaci
// interfejs miedzy pathfinderem a systemem animacji i rigidbody
// moze dzialac bez podpietego animatora, wtedy po prostu nie
// proboje wykonywac animacji
public class CharacterMovement : MonoBehaviour
{
    public float speed;
    
    private Vector3 movement;

    private Animator animator;
    private Rigidbody2D rb;
    private Unit unit;

    private void Awake()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        unit = gameObject.GetComponent<Unit>();

    }

    void Start()
    {
        // sprawdza czy jednostka zyje co jakis czas
        InvokeRepeating("IsDead", 0f, 0.1f);
    }

    void FixedUpdate()
    {
        // poruszanie postacia
        rb.MovePosition(rb.position + (Vector2)movement * speed * Time.fixedDeltaTime);

        // sprawdzanie czy mozna wykonac atak
        if (unit.currentTarget != null)
        {
            if(unit.currentAttack != null)
            {
                if (Vector3.Distance(gameObject.transform.position, unit.currentTarget.transform.position) <= unit.currentAttack.GetRange())
                {
                    unit.Attack(animator);
                }
            }
        }
    }

    public void ApplyMovement(Vector3 _movement)
    {
        if (unit.isAlive)
        {
            movement = _movement;

            if (animator != null)
            {
                animator.SetFloat("speed", Mathf.Abs(movement.magnitude));
                animator.SetFloat("Horizontal", movement.x);
                animator.SetFloat("Vertical", movement.y);
            }
        }
    }

    private void IsDead()
    {
        if (!unit.isAlive)
        {
            Die();
        }
    }

    private void Die()
    {
        if (animator != null)
        {
            animator.SetBool("isAlive", false);
        }

        movement = Vector3.zero;
    }
}
