using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public event Action<EnemyController> FinalizeEvent;

    HealthComponent healthComponent;
    float shotTimer;
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += ShipHealth_DeathEvent;
    }
    private void ShipHealth_DeathEvent()
    {
        Destroy();
    }
    public void Destroy()
    {
        if (FinalizeEvent != null)
            FinalizeEvent(this);
        Destroy(gameObject);
    }
}
