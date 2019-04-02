using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsExplosionComponent : MonoBehaviour
{
    public ObjectMovementComponent[] parts;
    HealthComponent healthComponent;
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += HealthComponent_DeathEvent;
    }
    private void HealthComponent_DeathEvent()
    {
        for (int i = 0; i < parts.Length; i++)
        {
            parts[i].transform.SetParent(null);
            parts[i].velocity = Random.insideUnitCircle * 10f + Vector2.down * 3f;
            //parts[i].angularVelocity = Random.Range(-120f, 120f);
        }
    }
}
