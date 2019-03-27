using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OverlapCircleAllComponent : MonoBehaviour, IOverlapAll
{
    public event Action<Collider2D[]> OverlappedEvent;
    public float overlapRadius;
    public LayerMask layerMask;
    Collider2D[] overlaps = new Collider2D[10];
    int count;
    void Update()
    {
        if (OverlappedEvent != null)
        {
            count = Physics2D.OverlapCircleNonAlloc(transform.position, overlapRadius, overlaps, layerMask);
            if (count > 0)
            {
                OverlappedEvent(overlaps);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}

