using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperFunctions
{
    /// <returns> returns GameObject at given viewport position or null </returns>
    public static GameObject GetWorldObject(Vector3 viewportPosition)
    {
        Vector3 pos = Camera.main.ScreenToWorldPoint(viewportPosition);
        Vector2 pos2D = new Vector2(pos.x, pos.y);
        RaycastHit2D hit = Physics2D.Raycast(pos2D, Vector2.zero);
        if (hit.collider != null)
        {
            return hit.collider.gameObject;
        } else
        {
            return null;
        }
    }
}
