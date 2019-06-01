using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class ShootingTargetModule : ShootingModule
{
    public BulletController bulletPrefab;
    public float shootingDelay;
    public float shootingInterval;
    public float bulletSpeed;
    public float bulletDamageAmount;
    public LayerMask targetLayers;
    public override IShooting InitializeObject(GameObject gameObject)
    {
        Transform target = GameObject.FindObjectOfType<GameController>().playerShip.transform;
        ShootingTargetComponent inst = gameObject.AddComponent<ShootingTargetComponent>();
        inst.Initialize(bulletPrefab, shootingDelay, shootingInterval, bulletSpeed, target, bulletDamageAmount, targetLayers);
        return inst;
    }
}
