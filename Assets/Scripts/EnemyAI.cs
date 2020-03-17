using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyState {
    IDLE,
    FOLLOW,
    ATTACK
};

// proste, ogolne ai przeciwnika
public class EnemyAI : MonoBehaviour
{
    CharacterPathfinding pathfinding;
    Unit unit;
    Animator animator;

    public float sightDistance = 5f;

    public EnemyState state;

    // Start is called before the first frame update
    void Start()
    {
        unit = GetComponent<Unit>();
        pathfinding = GetComponent<CharacterPathfinding>();
        // ! Poki co skrypt korzysta z pustego animatora, ale kiedys przydaloby sie cos podpiac !
        animator = new Animator();

        state = EnemyState.IDLE;

        InvokeRepeating("UpdateState", 0f, 0.3f);
    }

    // ta funkcja implementuje cala maszyne stanow
    void UpdateState()
    {
        if (state == EnemyState.IDLE)
        {
            LookForTargets();
        }
        else if (state == EnemyState.FOLLOW)
        {
            // jezeli nie ma celu to przechodzi w idle
            if (unit.currentTarget == null)
            {
                state = EnemyState.IDLE;
                return;
            }

            // sprawdzanie czy mozna wykonac atak
            if (Vector3.Distance(gameObject.transform.position, unit.currentTarget.transform.position) <= unit.currentAttack.GetRange())
            {
                // jezeli tak to zmienia stan na atakowanie
                state = EnemyState.ATTACK;
                return;
            }
        }
        else if (state == EnemyState.ATTACK)
        {
            // jezeli nie ma celu to przechodzi w idle
            if (unit.currentTarget == null)
            {
                state = EnemyState.IDLE;
            }
        }
    }

    private void Update()
    {
        if (state == EnemyState.ATTACK)
        {
            // sprawdzanie czy mozna wykonac atak
            if (unit.currentTarget != null)
            {
                if (unit.currentAttack != null)
                {
                    if (Vector3.Distance(gameObject.transform.position, unit.currentTarget.transform.position) <= unit.currentAttack.GetRange())
                    {
                        // jesli tak to atakuje
                        unit.Attack(animator);
                    }
                    else // jak nie to wraca do podazania
                    {
                        state = EnemyState.FOLLOW;
                        UpdateState();
                    }
                }
            }
        }
    }


    // wejscie w trigger przez gracza
    private void LookForTargets()
    {
        if (state == EnemyState.IDLE)
        {
            Collider2D[] colliders = Physics2D.OverlapCircleAll(gameObject.transform.position, sightDistance);

            // ustawi obiekt jako cel, jesli jest jednostka kontrolowalna przez gracza, a takze ma wiecej niz 0 hp
            foreach (Collider2D x in colliders)
            {
                if (x.gameObject.GetComponent<Unit>() != null)
                {
                    if (x.gameObject.GetComponent<Unit>().canBeControlledByPlayer)
                    {
                        if (x.gameObject.GetComponent<Unit>().isAlive)
                        {
                            pathfinding.SetTarget(x.transform);
                            unit.currentTarget = x.gameObject.GetComponent<Unit>();
                            // zmienia stan maszyny stanow na podazanie
                            state = EnemyState.FOLLOW;
                            UpdateState();
                        }
                    }
                }
            }
        }
    }
}
