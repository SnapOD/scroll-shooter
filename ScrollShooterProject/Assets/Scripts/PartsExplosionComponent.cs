using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartsExplosionComponent : MonoBehaviour
{
    public TrashController[] trash;
    HealthComponent healthComponent;
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += HealthComponent_DeathEvent;
    }

    private void HealthComponent_DeathEvent()
    {
        for (int i = 0; i < trash.Length; i++)
        {
            trash[i].transform.SetParent(null);
            trash[i].velocity = Random.insideUnitCircle * 10f + Vector2.down * 3f;
            trash[i].angularVelocity = Random.Range(-120f, 120f);
        }
    }
}
