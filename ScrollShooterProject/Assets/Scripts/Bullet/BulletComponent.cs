using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletComponent : MonoBehaviour
{
    public float damageAmount = 20f;
    public GameObject owner;
    public float overlapRadius = 0.1f;
    public Vector2 movement;
    void Start()
    {
        Destroy(gameObject, 5f);
    }
    private void Update()
    {
        transform.position += (Vector3)movement * Time.deltaTime;
        Collider2D collider2D = Physics2D.OverlapCircle(transform.position, overlapRadius);
        if (collider2D != null)
        {
            if (collider2D.gameObject.tag != owner.tag)
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
