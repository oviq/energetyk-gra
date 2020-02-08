using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour
{
    public float speed;

    private Rigidbody2D rb;
    private Vector3 movement;

    public Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        rb = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.MovePosition(rb.position + (Vector2)movement * speed * Time.fixedDeltaTime);
    }

    public void ApplyMovement(Vector3 _movement)
    {
        movement = _movement;

        animator.SetFloat("speed", Mathf.Abs(movement.magnitude));
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
    }
}
