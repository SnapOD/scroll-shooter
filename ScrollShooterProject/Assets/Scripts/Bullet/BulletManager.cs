using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    public BulletController bulletPrefab;
    public int count = 100;
    List<BulletController> pool;
    void Awake()
    {
        pool = new List<BulletController>();
        for (int i = 0; i < count; i++)
        {
            BulletController bulletController = Instantiate(bulletPrefab, transform);
            bulletController.gameObject.SetActive(false);
            pool.Add(bulletController);
            bulletController.BulletDisabledEvent += BulletController_BulletDisabledEvent;
        }
    }
    private void BulletController_BulletDisabledEvent(BulletController disabledBullet)
    {
        pool.Add(disabledBullet);
    }
    public BulletController GetBullet()
    {
        int index = pool.Count - 1;
        BulletController bulletController = pool[index];
        pool.RemoveAt(index);
        return bulletController;
    }
}
