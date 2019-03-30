using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectorComponent : MonoBehaviour
{
    public float collectRadius;
    public LayerMask layerMask;

    OverlapCircleAllComponent overlap;
    void Start()
    {
        overlap = gameObject.AddComponent<OverlapCircleAllComponent>();
        overlap.layerMask = layerMask;
        overlap.overlapRadius = collectRadius;
        overlap.OverlappedEvent += OverlappedEvent;
    }
    private void OverlappedEvent(Collider2D[] arg1, int arg2)
    {
        for (int i = 0; i < arg2; i++)
        {
            Destroy(arg1[i].gameObject);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collectRadius);
    }
}
