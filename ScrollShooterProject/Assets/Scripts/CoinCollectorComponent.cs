using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorComponent : MonoBehaviour
{
    public LayerMask layerMask;
    public float overlapRadius = 10f;
    public int colliderArrayLength = 20;
    Collider2D[] colliders;

    private void Start()
    {
        colliders = new Collider2D[colliderArrayLength];
    }
    void Update()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, overlapRadius, colliders, layerMask);
        for (int i = 0; i < count; i++)
        {
            ObjectMovementComponent obj = colliders[i].GetComponent<ObjectMovementComponent>();
            if (obj != null)
            {
                Destroy(obj.gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}
