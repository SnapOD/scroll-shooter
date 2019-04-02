using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollectorComponent : MonoBehaviour
{
    public event Action<Collider2D[], int> ObjectsCollectedEvent;
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
            arg1[i].gameObject.SetActive(false);
        }
        if (ObjectsCollectedEvent != null)
            ObjectsCollectedEvent(arg1, arg2);
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, collectRadius);
    }
}
