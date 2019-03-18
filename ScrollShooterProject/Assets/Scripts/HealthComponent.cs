using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class HealthComponent : MonoBehaviour
{
    public event Action HitEvent;
    public event Action DeathEvent;
    public float health = 100;
    public void Hit(float damageAmount)
    {
        health -= damageAmount;
        if (health <= 0)
        {
            health = 0;
            if (DeathEvent != null) DeathEvent();
        }
        if (HitEvent != null) HitEvent();
    }
}
