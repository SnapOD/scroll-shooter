using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OverlapCircleComponent : MonoBehaviour, IOverlap
{
    public event Action<Collider2D> OverlappedEvent;
    public float overlapRadius;
    public LayerMask layerMask;

    void Update()
    {
        if (OverlappedEvent != null)
        {
            Collider2D overlapped = Physics2D.OverlapCircle(transform.position, overlapRadius, layerMask);
            if (overlapped != null)
            {
                OverlappedEvent(overlapped);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}

