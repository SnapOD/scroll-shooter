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
    public float moveBackDelay;
    public GameObject enemyPrefab;
    public override event Action<QueueItem> CompletedEvent;

    int enemyCount;
    int spawnedCount;
    int destroyedCount;

    float timer;
    Dictionary<GameObject, int> pairs;
    Coroutine coroutine;
    MonoBehaviour monoBehaviour;

    public override QueueItem CreateInstance()
    {
        EnemyPointsGroup inst = (EnemyPointsGroup)ScriptableObject.CreateInstance(GetType());
        inst.points = (PointsPair[])points.Clone();
        inst.flySpeed = flySpeed;
        inst.spawnDelay = spawnDelay;
        inst.spawnInterval = spawnInterval;
        inst.moveBackDelay = moveBackDelay;
        inst.enemyPrefab = enemyPrefab;
        inst.pairs = new Dictionary<GameObject, int>();
        return inst;
    }
    public override void Run(MonoBehaviour monoBehaviour)
    {
        if (coroutine != null) return;
        enemyCount = points.Length;
        this.monoBehaviour = monoBehaviour;
        coroutine = monoBehaviour.StartCoroutine(RunCoroutine());
    }
    private IEnumerator RunCoroutine()
    {
        yield return new WaitForSeconds(spawnDelay);
        for (int i = 0; i < points.Length; i++)
        {
            GameObject enemyInst = GameObject.Instantiate(enemyPrefab, points[i].spawnPoint, Quaternion.identity);
            PointMoveComponent moveComponent = enemyInst.AddComponent<PointMoveComponent>();
            moveComponent.target = points[i].targetPoint;
            moveComponent.speed = flySpeed;
            moveComponent.MoveCompletedEvent += MoveCompletedEventHandler;
            enemyInst.GetComponent<HealthComponent>().DeathEvent += DeathEventHandler;
            spawnedCount++;
            pairs.Add(enemyInst, i);
            yield return new WaitForSeconds(spawnInterval);
        }
    }
    private IEnumerator MoveBackCoroutine(PointMoveComponent obj, Vector2 targetPoint)
    {
        yield return new WaitForSeconds(moveBackDelay);
        if (obj == null) yield break;

        obj.target = targetPoint;
        obj.Reset();
    }
    private void MoveCompletedEventHandler(PointMoveComponent obj)
    {
        bool contains = pairs.ContainsKey(obj.gameObject);
        if (!contains)
        {
            obj.GetComponent<EnemyController>().Destroy();
            EnemyDestroyed();
        }
        else
        {
            int index = pairs[obj.gameObject];
            monoBehaviour.StartCoroutine(MoveBackCoroutine(obj, points[index].spawnPoint));
            pairs.Remove(obj.gameObject);
        }
    }
    private void DeathEventHandler() { EnemyDestroyed(); }
    private void EnemyDestroyed()
    {
        destroyedCount++;
        if (enemyCount == spawnedCount && spawnedCount == destroyedCount)
            if (CompletedEvent != null)
                CompletedEvent(this);
    }
}
