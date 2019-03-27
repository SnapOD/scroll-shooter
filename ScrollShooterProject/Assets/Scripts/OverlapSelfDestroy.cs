using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverlapSelfDestroy : MonoBehaviour
{
    IOverlap overlap;
    HealthComponent health;
    void Start()
    {
        overlap = GetComponent<IOverlap>();
        health = GetComponent<HealthComponent>();
        overlap.OverlappedEvent += Overlap_OverlappedEvent;
    }
    private void Overlap_OverlappedEvent(Collider2D obj)
    {
        health.Hit(float.MaxValue);
    }
}
