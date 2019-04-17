using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyPathGroup : QueueItem
{
    public override event Action<QueueItem> CompletedEvent;
    public PathScriptableObject path;
    public GameObject enemyPrefab;
    public int enemiesCount;
    public float spawnEnemiesInterval;
    public float moveSpeed;

    private bool isInstance = false;
    private float timer;
    private int spawnedCount;
    private Coroutine coroutine;
    private int destroyedCount;

    public override void Run(MonoBehaviour behaviour)
    {
        if (coroutine == null)
            coroutine = behaviour.StartCoroutine(RunCoroutine());
    }
    private void Initialize(EnemyPathGroup source)
    {
        //if (!IsInstance) throw new System.InvalidOperationException("Obj is not instance");
        path = source.path;
        enemyPrefab = source.enemyPrefab;
        enemiesCount = source.enemiesCount;
        spawnEnemiesInterval = source.spawnEnemiesInterval;
        moveSpeed = source.moveSpeed;
    }
    public override QueueItem CreateInstance()
    {
        EnemyPathGroup instance = (EnemyPathGroup)ScriptableObject.CreateInstance(GetType());
        instance.isInstance = true;
        instance.Initialize(this);
        return instance;
    }
    private IEnumerator RunCoroutine()
    {
        while (spawnedCount != enemiesCount)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = spawnEnemiesInterval;
                Vector2 point = path.points[0];
                GameObject enemyInstance = Instantiate(enemyPrefab, point, Quaternion.identity);
                enemyInstance.AddComponent<PathMoveComponent>().path = path;
                enemyInstance.GetComponent<HealthComponent>().DeathEvent += EnemyDestroyedHandler;
                enemyInstance.GetComponent<EnemyController>().OutOfScreenEvent += EnemyPathGroup_OutOfScreenEvent;
                spawnedCount++;
            }
            yield return null;
        }
        yield return new WaitUntil(CompletedPredicate);
        if (CompletedEvent != null)
            CompletedEvent(this);
    }

    private void EnemyPathGroup_OutOfScreenEvent(GameObject obj)
    {
        EnemyDestroyedHandler();
    }
    private void EnemyDestroyedHandler()
    {
        destroyedCount++;
    }

    private bool CompletedPredicate()
    {
        return enemiesCount == spawnedCount && spawnedCount == destroyedCount;
    }

}
