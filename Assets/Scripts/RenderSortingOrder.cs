using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSortingOrder : MonoBehaviour
{
    private Renderer renderer;

    private float BaseOrder = 0;

    void Awake()
    {
        renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        renderer.sortingOrder = (int)(BaseOrder - transform.position.y * 10);
    }
}
