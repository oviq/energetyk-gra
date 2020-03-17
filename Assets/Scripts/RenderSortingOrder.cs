using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RenderSortingOrder : MonoBehaviour
{
    private Renderer _renderer;

    private float BaseOrder = 0;

    void Awake()
    {
        _renderer = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        _renderer.sortingOrder = (int)(BaseOrder - transform.position.y * 10);
    }
}
