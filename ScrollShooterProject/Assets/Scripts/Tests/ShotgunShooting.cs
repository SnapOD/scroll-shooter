using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShotgunShooting : MonoBehaviour
{
    public ShotgunBullet bulletPrefab;
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
        for (int i = 0; i < 10; i++)
        {
            float mult = 20;
            Vector2 velocity = (Quaternion.Euler(0f, 0f, (Random.value - 0.5f) * mult) * Vector3.up) * (bulletSpeed + (Random.value - 0.5f) * 3);
            ShotgunBullet bulletInst = Instantiate(bulletPrefab, spawnPoint.position, Quaternion.identity);
            bulletInst.Velocity = velocity;
            Destroy(bulletInst, 10f);
        }
    }
}
