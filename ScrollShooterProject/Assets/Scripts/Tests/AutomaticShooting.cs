using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AutomaticShooting : MonoBehaviour
{
    public AutomaticBullet bulletPrefab;
    public float bulletSpeed;

    public float shotInterval;

    Transform spawnPoint;
    float t;
    // Use this for initialization
    void Start()
    {
        spawnPoint = GetComponentInChildren<SpawnPoint>().transform;
    }

    // Update is called once per frame
    void Update()
    {
        t -= Time.deltaTime;
        if (t <= 0f)
        {
            t = shotInterval;
            Shot();
        }
    }
    void Shot()
    {
        AutomaticBullet bulletInst = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
        bulletInst.Velocity = Vector2.up * bulletSpeed;
        Destroy(bulletInst, 10f);
    }
}
