using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollectorComponent : MonoBehaviour
{
    public float overlapRadius = 10f;
    Collider2D[] coinsColliders;

    private void Start()
    {
        coinsColliders = new Collider2D[50];
    }

    void Update()
    {
        int count = Physics2D.OverlapCircleNonAlloc(transform.position, overlapRadius, coinsColliders);
        for (int i = 0; i < count; i++)
        {
            CoinController coinController = coinsColliders[i].GetComponent<CoinController>();
            if (coinController != null)
            {
                Destroy(coinController.gameObject);
            }
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}
