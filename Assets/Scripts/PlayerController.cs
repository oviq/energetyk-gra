using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Vector3 movement;

    public GameObject boy;
    public GameObject gal;

    public CameraFollow cam;

    private CharacterMovement char_movement;
    [SerializeField] private Unit char_unit;

    private bool state;

    // Start is called before the first frame update
    void Start()
    {
        SetCharacter(boy);
        state = false;
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        char_movement.ApplyMovement(movement);

        if (Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))
        {
            char_movement.ApplyMovement(Vector3.zero);

            state = !state;

            if (state == true)
            {
                SetCharacter(gal);
            }

            if (state == false)
            {
                SetCharacter(boy);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            char_unit.Attack();
        }
    }

    void SetCharacter(GameObject character)
    {
        cam.target = character;
        char_movement = character.GetComponent<CharacterMovement>();
        char_unit = character.GetComponent<Unit>();
    }
}


