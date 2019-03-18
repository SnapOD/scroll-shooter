using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public float damageAmount = 20f;
    public GameObject owner;
    public float overlapRadius = 0.1f;
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, overlapRadius);
        if (collider2D != null)
        {
            if (collider2D.gameObject != owner)
            {
                HealthComponent shipHealth = collider2D.GetComponent<HealthComponent>();
                if (shipHealth != null)
                    shipHealth.Hit(damageAmount);
                Destroy(gameObject);
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, overlapRadius);
    }
}
