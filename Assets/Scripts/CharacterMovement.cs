using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;
    
    private Vector3 movement;

    private Animator animator;
    private Rigidbody2D rb;
    private Unit unit;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
        unit = gameObject.GetComponent<Unit>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)movement * speed * Time.fixedDeltaTime);
    }

    public void ApplyMovement(Vector3 _movement)
    {
        if (unit.isAlive)
        {
            movement = _movement;

            animator.SetFloat("speed", Mathf.Abs(movement.magnitude));
            animator.SetFloat("Horizontal", movement.x);
            animator.SetFloat("Vertical", movement.y);
        }
    }

    public void Die()
    {
        animator.SetBool("isAlive", false);
    }
}
