using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class OverlapDamageComponent : MonoBehaviour
{
    IOverlap overlap;
    public event Action DamageAppliedEvent;
    public float damageAmount;
    void Start()
    {
        overlap = GetComponent<IOverlap>();
        overlap.OverlappedEvent += Overlap_OverlappedEvent;
    }

    private void Overlap_OverlappedEvent(Collider2D obj)
    {
        HealthComponent healthComponent = obj.GetComponent<HealthComponent>();
        if (healthComponent != null)
            healthComponent.Hit(damageAmount);
        if (DamageAppliedEvent != null)
            DamageAppliedEvent();

    }
}
