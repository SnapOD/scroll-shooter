﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootingTargetComponent : MonoBehaviour, IShooting
{

    public event Action<IShooting, Component> ShotEvent;
    public bool IsEnabled { get { return isEnabled; } set { ResetTimers(); isEnabled = value; } }
    bool isEnabled = true;
    public BulletController bulletPrefab;
    public float shootingDelay;
    public float shootingInterval;
    public float bulletSpeed;
    public Transform target;
    public float bulletDamageAmount;
    public LayerMask targetLayers;
    float delayTimer;
    float intervalTimer;

    Transform spawnPoint;
    BulletManager bulletManager;

    public void Initialize(BulletController bulletPrefab, float shootingDelay, float shootingInterval, float bulletSpeed, Transform target, float bulletDamageAmount, LayerMask targetLayers)
    {
        this.bulletPrefab = bulletPrefab;
        this.shootingDelay = shootingDelay;
        this.shootingInterval = shootingInterval;
        this.bulletSpeed = bulletSpeed;
        this.target = target;
        this.bulletDamageAmount = bulletDamageAmount;
        this.targetLayers = targetLayers;
    }
    private void Start()
    {
        ResetTimers();
        spawnPoint = GetComponent<SpawnPoint>().transform;
        bulletManager = FindObjectOfType<BulletManager>();

    }
    private void Update()
    {
        if (!isEnabled)
            return;
        if (delayTimer > 0f)
        {
            delayTimer -= Time.deltaTime;
            return;
        }
        if (intervalTimer > 0f)
        {
            intervalTimer -= Time.deltaTime;
        }
        else
        {
            intervalTimer = shootingInterval;
            Shot();
            Debug.Log("OK");
        }
    }
    private void Shot()
    {
        BulletController bulletInst = bulletManager.GetBullet();

        bulletInst.gameObject.SetActive(true);
        bulletInst.transform.position = spawnPoint.position;
        Vector2 direction = target.transform.position - bulletInst.transform.position;
        direction.Normalize();
        bulletInst.Movement = direction * bulletSpeed;
        bulletInst.DamageAmount = bulletDamageAmount;
        bulletInst.LayerMask = targetLayers;

        if (ShotEvent != null)
            ShotEvent(this, bulletInst);
    }
    private void ResetTimers()
    {
        delayTimer = shootingDelay;
        intervalTimer = 0;
    }
}
