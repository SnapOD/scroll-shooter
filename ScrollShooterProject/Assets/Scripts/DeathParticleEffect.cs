﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathParticleEffect : MonoBehaviour
{
    public ParticleSystem effectPrefab;
    HealthComponent healthComponent;
    void Start()
    {
        healthComponent = GetComponentInChildren<HealthComponent>();
        healthComponent.DeathEvent += DeathEventHandler;
    }
    private void DeathEventHandler()
    {
        ParticleSystem inst = Instantiate(effectPrefab, transform.position, Quaternion.identity);
        Destroy(inst.gameObject, inst.main.duration);
    }
}
