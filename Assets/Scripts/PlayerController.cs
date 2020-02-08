using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 movement;

    public GameObject boy;
    public GameObject gal;

    public CameraFollow cam;

    private CharacterMovement controller;
    private bool state;

    // Start is called before the first frame update
    void Start()
    {
        cam.target = boy;
        controller = boy.GetComponent<CharacterMovement>();
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        controller.ApplyMovement(movement);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            controller.ApplyMovement(Vector3.zero);

            state = !state;

            if (state == true)
            {
                cam.target = gal;
                controller = gal.GetComponent<CharacterMovement>();
            }

            if (state == false)
            {
                cam.target = boy;
                controller = boy.GetComponent<CharacterMovement>();
            }
        }
    }
}
