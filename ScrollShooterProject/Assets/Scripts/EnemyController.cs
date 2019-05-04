using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyController : MonoBehaviour
{
    public event Action<EnemyController> FinalizeEvent;
    public event Action<GameObject> OutOfScreenEvent;
    ShootComponent shootComponent;
    //MoveComponent moveComponent;
    HealthComponent healthComponent;
    public BulletController bulletPrefab;
    public float bulletSpeed;
    public float damageAmount = 20f;
    public float shotInterval = 0.1f;

    public bool shootingEnabled;
    public bool movementEnabled;

    float shotTimer;
    void Start()
    {
        shootComponent = GetComponent<ShootComponent>();
        //moveComponent = GetComponent<MoveComponent>();
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += ShipHealth_DeathEvent;
    }
    private void ShipHealth_DeathEvent()
    {
        Destroy();
    }
    void Update()
    {
        //if (movementEnabled)
        //    moveComponent.Move(Vector2.down, 3f);

        shotTimer -= Time.deltaTime;
        if (shootingEnabled && shotTimer <= 0)
        {
            shotTimer = shotInterval;
            shootComponent.Shot(bulletPrefab, damageAmount, transform.position, Vector2.down, bulletSpeed);
        }
        if (OutOfScreenEvent != null && transform.position.y < -2f)
            OutOfScreenEvent(gameObject);
    }
    public void Destroy()
    {
        if (FinalizeEvent != null)
            FinalizeEvent(this);
        Destroy(gameObject);
    }
}
