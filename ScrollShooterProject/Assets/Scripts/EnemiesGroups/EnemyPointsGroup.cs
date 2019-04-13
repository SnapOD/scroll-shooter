using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyPointsGroup : QueueItem
{
    [Serializable]
    public struct PointsPair
    {
        public Vector2 spawnPoint;
        public Vector2 targetPoint;
    }
    public PointsPair[] points;
    public float flySpeed;
    public float spawnDelay;
    public float spawnInterval;
    public GameObject enemyPrefab;
    public override event Action<QueueItem> CompletedEvent;

    int enemyCount;
    int spawnedCount;
    int destroyedCount;
    float timer;
    Coroutine coroutine;
    public override QueueItem CreateInstance()
    {
        EnemyPointsGroup inst = (EnemyPointsGroup)ScriptableObject.CreateInstance(GetType());
        inst.points = (PointsPair[])points.Clone();
        inst.flySpeed = flySpeed;
        inst.spawnDelay = spawnDelay;
        inst.spawnInterval = spawnInterval;
        inst.enemyPrefab = enemyPrefab;
        return inst;
    }

    public override void Run(MonoBehaviour monoBehaviour)
    {
        if (coroutine != null) return;
        enemyCount = points.Length;

        coroutine = monoBehaviour.StartCoroutine(RunCoroutine());
    }

    private IEnumerator RunCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        for (int i = 0; i < points.Length; i++)
        {
            GameObject enemyInst = GameObject.Instantiate(enemyPrefab, points[i].spawnPoint, Quaternion.identity);
            PointMoveComponent moveComponent = enemyInst.GetComponent<PointMoveComponent>();
            moveComponent.target = points[i].targetPoint;
            moveComponent.speed = flySpeed;
            enemyInst.GetComponent<HealthComponent>().DeathEvent += EnemyDestroyed;
            enemyInst.GetComponent<EnemyController>().OutOfScreenEvent += EnemyPointsGroup_OutOfScreenEvent;
            spawnedCount++;
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private void EnemyPointsGroup_OutOfScreenEvent(GameObject obj)
    {
        EnemyDestroyed();
    }

    private void EnemyDestroyed()
    {
        destroyedCount++;
        if (enemyCount == spawnedCount && spawnedCount == destroyedCount)
            if (CompletedEvent != null)
                CompletedEvent(this);
    }
}
