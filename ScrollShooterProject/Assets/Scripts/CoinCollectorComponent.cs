using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorComponent : MonoBehaviour
{
    public LayerMask layerMask;
    public float overlapRadius = 10f;
    Collider2D[] coinsColliders;

    private void Start()
    {
        coinsColliders = new Collider2D[50];
    }
    void Update()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, overlapRadius, coinsColliders, layerMask);
        for (int i = 0; i < count; i++)
        {
            ObjectMovementComponent obj = coinsColliders[i].GetComponent<ObjectMovementComponent>();
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
