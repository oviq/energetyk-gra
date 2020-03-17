using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


// glowna klasa posredniczaca miedzy character movementem a systemem wyszukiwania tras
public class CharacterPathfinding : MonoBehaviour
{

    public Transform target;
    GameObject targetGameObject;
    public float nextWaypointDistance;
    public float defaultMaxDistanceToTarget;
    float maxDistanceToTarget;

    Path path;
    int currentWaypoint = 0;

    Seeker seeker;
    Rigidbody2D rb;
    CharacterMovement cm;

    // Start is called before the first frame update
    void Start()
    {
        seeker = GetComponent<Seeker>();
        rb = GetComponent<Rigidbody2D>();
        cm = GetComponent<CharacterMovement>();

        InvokeRepeating("UpdatePath", 0f, 0.8f);
    }

    void UpdatePath()
    {
        if (target != null)
        {
            if (seeker.IsDone())
            {
                seeker.StartPath(rb.position, target.position, OnPathComplete);
            }
        } 
    }

    void OnPathComplete(Path p)
    {
        if (!p.error)
        {
            path = p;
            currentWaypoint = 0;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (target != null)
        {
            if (path == null)
            {
                return;
            }

            if (currentWaypoint >= path.vectorPath.Count)
            {
                return;
            }

            Vector2 direction = ((Vector2)path.vectorPath[currentWaypoint] - rb.position).normalized;

            float distance = Vector2.Distance(rb.position, (Vector2)path.vectorPath[currentWaypoint]);
            if (distance < nextWaypointDistance)
            {
                currentWaypoint++;
            }

            float distanceToTarget = Vector2.Distance(rb.position, target.position);

            if (distanceToTarget >= maxDistanceToTarget)
            {
                cm.ApplyMovement(direction);
            }
            else // to tutaj ogarnia sytuacje w ktorej obiekt znalazl sie wystarczajaco blisko celu
            {
                // zatrzymywansko
                cm.ApplyMovement(Vector3.zero);

                // detargetowansko
                target = null;

                // niszczenie znacznika jesli taki jest
                if (targetGameObject != null)
                {
                    Destroy(targetGameObject);
                    targetGameObject = null;
                }

            }
        }
    }

    public void SetTarget(Transform t)
    {
        maxDistanceToTarget = defaultMaxDistanceToTarget;
        target = t;
        UpdatePath();
    }


    /// <summary>
    /// jak cos to uzywac tylko do znacznikow,
    /// automatycznie usuwa obiekty
    /// </summary>
    /// <param name="g"></param>
    public void SetTarget(GameObject g)
    {
        maxDistanceToTarget = defaultMaxDistanceToTarget;
        // niszczenie poprzedniego znacznika
        Destroy(targetGameObject);
        target = g.transform;
        targetGameObject = g;
        UpdatePath();
    }

    public void SetTarget(Transform t, float tolerance)
    {
        maxDistanceToTarget = tolerance;
        target = t;
        UpdatePath();
    }
}
