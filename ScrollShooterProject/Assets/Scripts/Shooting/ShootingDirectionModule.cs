using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShootingDirectionModule : ShootingModule
{
    public BulletController bulletPrefab;
    public float shootingDelay;
    public float shootingInterval;
    public float bulletSpeed;
    public Vector2 direction;
    public float bulletDamageAmount;
    public LayerMask targetLayers;
    public override IShooting InitializeObject(GameObject gameObject)
    {
        ShootingDownComponent inst = gameObject.AddComponent<ShootingDownComponent>();
        inst.Initialize(bulletPrefab, shootingDelay, shootingInterval, bulletSpeed, direction, bulletDamageAmount, targetLayers);
        return inst;
    }
}
