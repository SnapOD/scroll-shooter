using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class BulletController : MonoBehaviour
{
    public event Action<BulletController> BulletDisabledEvent;
    OverlapCircleComponent overlapComponent;
    OverlapDamageComponent damageComponent;
    ObjectMovementComponent movementComponent;

    public Bounds bounds;

    public float DamageAmount { get { return damageComponent.damageAmount; } set { damageComponent.damageAmount = value; } }
    public Vector2 Movement { get { return movementComponent.velocity; } set { movementComponent.velocity = value; } }
    public LayerMask LayerMask { get { return overlapComponent.layerMask; } set { overlapComponent.layerMask = value; } }
    private void Awake()
    {
        overlapComponent = GetComponent<OverlapCircleComponent>();
        damageComponent = GetComponent<OverlapDamageComponent>();
        movementComponent = GetComponent<ObjectMovementComponent>();
        damageComponent.DamageAppliedEvent += DamageComponent_DamageAppliedEvent;
    }
    private void DamageComponent_DamageAppliedEvent()
    {
        gameObject.SetActive(false);
        if (BulletDisabledEvent != null)
            BulletDisabledEvent(this);
    }
    private void Update()
    {
        if (!bounds.Contains(transform.position))
            DamageComponent_DamageAppliedEvent();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireCube(bounds.center, bounds.size);
    }
}
