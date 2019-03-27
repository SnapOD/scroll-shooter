using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class ShipPreferences : ScriptableObject
{
    [SerializeField] Vector2 moveRange;
    [SerializeField] float moveSpeed;
    [SerializeField] float shotInterval;
    [SerializeField] float bulletSpeed;
    [SerializeField] float damageAmount;
    [SerializeField] BulletController bulletPrefab;
    public Vector2 MoveRange { get { return moveRange; } }
    public float MoveSpeed { get { return moveSpeed; } }
    public float ShotInterval { get { return shotInterval; } }
    public BulletController BulletPrefab { get { return bulletPrefab; } }
    public float BulletSpeed { get { return bulletSpeed; } }
    public float DamageAmount
    {
        get
        {
            return damageAmount;
        }
    }
}
