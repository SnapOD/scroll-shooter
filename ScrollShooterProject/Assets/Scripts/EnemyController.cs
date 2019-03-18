using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    ShootComponent shootComponent;
    MoveComponent moveComponent;
    HealthComponent healthComponent;
    public BulletComponent bulletPrefab;
    public float bulletSpeed;
    public float shotInterval = 0.1f;

    public bool shootingEnabled;
    public bool movementEnabled;

    float shotTimer;
    void Start()
    {
        shootComponent = GetComponent<ShootComponent>();
        moveComponent = GetComponent<MoveComponent>();
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += ShipHealth_DeathEvent;
    }
    private void ShipHealth_DeathEvent()
    {
        Destroy(gameObject);
    }
    void Update()
    {
        if (movementEnabled)
            moveComponent.Move(Vector2.down, 3f);

        shotTimer += Time.deltaTime;
        if (shootingEnabled && shotTimer >= shotInterval)
        {
            shotTimer = 0;
            shootComponent.Shot(bulletPrefab, transform.position, Vector2.down, bulletSpeed);
        }

    }
}
