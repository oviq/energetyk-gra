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

    public float sightDistance = 5f;

    EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        pathfinding = GetComponent<CharacterPathfinding>();

        state = EnemyState.IDLE;

        InvokeRepeating("UpdateState", 0f, 0.5f);
        InvokeRepeating("LookForTargets", 0f, 0.6f);
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


    // wejscie w trigger przez gracza
    private void LookForTargets()
    {
        if (state == EnemyState.IDLE)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, sightDistance);

            // ustawi obiekt jako cel, jesli jest jednostka kontrolowalna przez gracza
            foreach (Collider2D x in colliders)
            {
                if (x.gameObject.GetComponent<Unit>() != null)
                {
                    if (x.gameObject.GetComponent<Unit>().canBeControlledByPlayer)
                    {
                        pathfinding.SetTarget(x.transform);
                    }
                }
            }
        }
    }
}
