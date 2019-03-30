using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootComponent : MonoBehaviour
{
    BulletManager bulletManager;
    public LayerMask targetLayers;
    public event Action ShotEvent;
    private void Awake()
    {
        bulletManager = FindObjectOfType<BulletManager>();
    }
    public void Shot(BulletController bulletPrefab, float damageAmount, Vector2 spawnPoint, Vector2 direction, float speed)
    {
        BulletController bulletInst = bulletManager.GetBullet();

        bulletInst.gameObject.SetActive(true);
        bulletInst.transform.position = spawnPoint;
        bulletInst.Movement = direction * speed;
        bulletInst.DamageAmount = damageAmount;
        bulletInst.LayerMask = targetLayers;
    }
}
