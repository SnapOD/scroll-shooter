using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunBullet : MonoBehaviour
{
    public float time = 1f;
    public float damage = 100f;
    IOverlap overlap;
    ObjectMovementComponent movementComponent;
    Vector3 scale;

    public float t;

    public Vector2 Velocity { get { return movementComponent.velocity; } set { movementComponent.velocity = value; } }
    // Use this for initialization
    void Awake()
    {
        scale = transform.localScale;
        t = time;
        overlap = GetComponent<IOverlap>();
        movementComponent = GetComponent<ObjectMovementComponent>();
        overlap.OverlappedEvent += Overlap_OverlappedEvent;
    }

    private void Overlap_OverlappedEvent(Collider2D obj)
    {
        HealthComponent healthComponent = obj.GetComponentInChildren<HealthComponent>();
        if (healthComponent != null)
            healthComponent.Hit(damage);
        Destroy(gameObject);
    }
    private void Update()
    {
        t -= Time.deltaTime;
        
        if (t < 0.1f)
            Destroy(gameObject);
        Vector3 l = Vector3.Lerp(Vector2.zero, scale, t / time);
        transform.localScale = l;

    }
}
