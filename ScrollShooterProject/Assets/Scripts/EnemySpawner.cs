using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class EnemySpawner : MonoBehaviour
{
    public event Action SpawnEndEvent;
    public event Action EnemyDestroyedEvent;
    public event Action AllEnemiesDestroyedEvent;
    public float yPosition = 10f;
    public float xRange = 10f;
    public float interval = 2f;
    public GameObject enemyPrefab;
    public int spawnCount = 10;
    public int spawned;
    public int alive;

    Coroutine spawnCoroutine;

    public void StartSpawn()
    {
        spawnCoroutine = StartCoroutine(SpawnCoroutine());
    }
    public void StopSpawn()
    {
        StopCoroutine(spawnCoroutine);
        spawnCoroutine = null;
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float xRandom = UnityEngine.Random.Range(0, xRange) - xRange / 2;
            GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(xRandom, yPosition), enemyPrefab.transform.rotation);
            enemyInst.GetComponent<HealthComponent>().DeathEvent += EnemySpawner_DeathEvent;
            enemyInst.GetComponent<EnemyController>().OutOfScreenEvent += EnemySpawner_OutOfScreenEvent;
            spawned++;
            alive++;
            if (spawnCount == spawned)
                break;
            yield return new WaitForSeconds(interval);
        }
        spawnCoroutine = null;
        if (SpawnEndEvent != null)
            SpawnEndEvent();
    }

    private void EnemySpawner_OutOfScreenEvent(GameObject gameObject)
    {
        Destroy(gameObject);
        DecreaseAlive();
    }

    private void EnemySpawner_DeathEvent()
    {
        DecreaseAlive();
    }
    private void DecreaseAlive()
    {
        alive--;
        if (spawnCoroutine == null && alive == 0 && AllEnemiesDestroyedEvent != null)
            AllEnemiesDestroyedEvent();

    }
    private void OnDrawGizmosSelected()
    {
        Vector2 left = new Vector2(xRange / 2 - xRange, yPosition);
        Vector2 right = new Vector2(xRange / 2, yPosition);
        Gizmos.DrawLine(left, right);
    }

}
