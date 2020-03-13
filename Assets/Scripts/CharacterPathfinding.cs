using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Pathfinding;


// glowna klasa posredniczaca miedzy character movementem a systemem wyszukiwania tras
public class CharacterPathfinding : MonoBehaviour
{

    public Transform target;
    public float nextWaypointDistance;
    public float maxDistanceToTarget;

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

        InvokeRepeating("UpdatePath", 0f, 0.5f);
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
            else
            {
                cm.ApplyMovement(Vector3.zero);
            }
        }
    }

    public void SetTarget(Transform t)
    {
        target = t;
        UpdatePath();
    }
}
