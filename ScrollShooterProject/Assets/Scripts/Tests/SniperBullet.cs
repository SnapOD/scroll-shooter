using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SniperBullet : MonoBehaviour
{

    public float damage = 300f;
    IOverlap overlap;
    ObjectMovementComponent movementComponent;

    public Vector2 Velocity { get { return movementComponent.velocity; } set { movementComponent.velocity = value; } }
    // Use this for initialization
    void Awake()
    {
        overlap = GetComponent<IOverlap>();
        movementComponent = GetComponent<ObjectMovementComponent>();
        overlap.OverlappedEvent += Overlap_OverlappedEvent;
    }

    private void Overlap_OverlappedEvent(Collider2D obj)
    {
        HealthComponent healthComponent = obj.GetComponentInChildren<HealthComponent>();
        if (healthComponent != null)
            healthComponent.Hit(damage);
        //Destroy(gameObject);
    }
    private void Update()
    {
        if (transform.position.y > 30f)
            Destroy(gameObject);
    }
}
