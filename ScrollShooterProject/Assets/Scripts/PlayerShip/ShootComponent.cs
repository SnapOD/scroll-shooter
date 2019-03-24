using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootComponent : MonoBehaviour
{
    public event Action ShotEvent;
    public void Shot(BulletComponent bulletPrefab, float damageAmount, Vector2 spawnPoint, Vector2 direction, float speed)
    {
        BulletComponent bulletInst = Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
        bulletInst.damageAmount = damageAmount;
        bulletInst.ownerTag = gameObject.tag;
        bulletInst.movement = direction * speed;
    }
}
