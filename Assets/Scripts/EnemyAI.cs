using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum EnemyState {
    IDLE,
    FOLLOW,
    ATTACK
};


// proste, ogolne ai przeciwnika
public class EnemyAI : MonoBehaviour
{
    CharacterPathfinding pathfinding;
    Unit unit;

    EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        pathfinding = GetComponent<CharacterPathfinding>();

        state = EnemyState.IDLE;

        InvokeRepeating("UpdateState", 0.5f, 0);
    }

    // Update is called once per frame
    void Update()
    {

    }


    // ta funkcja implementuje cala maszyne stanow
    void UpdateState()
    {
        if (state == EnemyState.IDLE)
        {
            
        }
        else if (state == EnemyState.FOLLOW)
        {

        }
        else if (state == EnemyState.ATTACK)
        {

        }
    }

    // wejscie w trigger przez cokolwiek
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<CharacterMovement>()!=null)
        {
            pathfinding.SetTarget(collision.transform);
        }
        
    }
}
