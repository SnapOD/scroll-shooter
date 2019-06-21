using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public ShipPreferences shipPreferences;
    public Transform weaponPoint;
    IInputSource inputSource;
    MoveComponent moveComponent;
    ShootComponent shootComponent;
    HealthComponent shipHealth;

    public bool shootingEnabled;
    public bool movementEnabled;

    float shotTimer;
    // Use this for initialization
    void Start()
    {

        //inputSource = GetComponent<IInputSource>();

        if (Application.platform == RuntimePlatform.Android)
            inputSource = GetComponent<TouchInput>();
        else
            inputSource = GetComponent<IInputSource>();

        moveComponent = GetComponent<MoveComponent>();
        shootComponent = GetComponent<ShootComponent>();
        shipHealth = GetComponentInChildren<HealthComponent>();
        shipHealth.DeathEvent += ShipHealth_DeathEvent;
    }

    private void ShipHealth_DeathEvent()
    {
        Destroy(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 0f)
            return;

        if (movementEnabled)
            moveComponent.Move(inputSource.Direction, shipPreferences.MoveSpeed);

        shotTimer += Time.deltaTime;
        if (shootingEnabled && shotTimer >= shipPreferences.ShotInterval)
        {
            shotTimer = 0;
            shootComponent.Shot(shipPreferences.BulletPrefab, shipPreferences.DamageAmount, weaponPoint.position, Vector2.up, shipPreferences.BulletSpeed);
        }
    }
}
