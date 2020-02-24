using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    public List<Transform> targets;

    void FixedUpdate()
    {
        if(targets.Count > 0)
        {
            Vector3 newPosition = Vector3.zero + new Vector3(0, 0, transform.position.z);

            foreach (Transform x in targets)
            {
                newPosition.x += x.position.x;
                newPosition.y += x.position.y;
            }

            newPosition.x /= targets.Count;
            newPosition.y /= targets.Count;

            transform.position = newPosition;
        }


    }
}
