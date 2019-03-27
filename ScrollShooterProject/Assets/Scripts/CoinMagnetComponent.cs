using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinMagnetComponent : MonoBehaviour
{
    public LayerMask coinsLayer;

    public float overlapRadius = 10f;
    Collider2D[] coinsColliders;
    private void Start()
    {
        coinsColliders = new Collider2D[50];
    }
    void Update()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, overlapRadius, coinsColliders, coinsLayer);
        for (int i = 0; i < count; i++)
        {
            ObjectMovementComponent objectMovement = coinsColliders[i].GetComponent<ObjectMovementComponent>();
            if (objectMovement != null)
            {
                Vector2 dir = transform.position - objectMovement.transform.position;
                dir.Normalize();
                objectMovement.movement += dir;
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}
