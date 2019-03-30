using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMagnetComponent : MonoBehaviour
{
    public float magnetRadius;
    public float magnetForce;
    public LayerMask layerMask;

    OverlapCircleAllComponent overlap;
    void Start()
    {
        overlap = gameObject.AddComponent<OverlapCircleAllComponent>();
        overlap.layerMask = layerMask;
        overlap.overlapRadius = magnetRadius;
        overlap.OverlappedEvent += Overlap_OverlappedEvent;
    }
    private void Overlap_OverlappedEvent(Collider2D[] colliders, int count)
    {
        for (int i = 0; i < count; i++)
        {
            ObjectMovementComponent obj = colliders[i].GetComponent<ObjectMovementComponent>();
            if (obj != null)
            {
                Vector2 dir = transform.position - obj.transform.position;
                dir.Normalize();
                obj.movement += dir * magnetForce * Time.deltaTime;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, magnetRadius);
    }
}
