using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ShootComponent : MonoBehaviour
{
    public event Action ShotEvent;
    public void Shot(BulletComponent bulletPrefab, Vector2 spawnPoint, Vector2 direction, float speed)
    {
        BulletComponent bulletInst = Instantiate(bulletPrefab, spawnPoint, Quaternion.identity);
        bulletInst.owner = gameObject;
        bulletInst.GetComponent<Rigidbody2D>().velocity = direction * speed;
    }
}
