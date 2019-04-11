using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyPathGroup : EnemyGroup
{
    public PathScriptableObject path;
    public GameObject enemyPrefab;
    public int enemiesCount;
    public float spawnEnemiesInterval;
    public float moveSpeed;
    public override bool IsInstance
    {
        get
        {
            return isInstance;
        }
    }

    private bool isInstance = false;
    private float timer;
    private int spawnedCount;
    private void Initialize(EnemyPathGroup source)
    {
        if (!IsInstance) throw new System.InvalidOperationException("Obj is not instance");
        path = source.path;
        enemyPrefab = source.enemyPrefab;
        enemiesCount = source.enemiesCount;
        spawnEnemiesInterval = source.spawnEnemiesInterval;
        moveSpeed = source.moveSpeed;
    }
    public override EnemyGroup CreateInstance()
    {
        EnemyPathGroup instance = (EnemyPathGroup)ScriptableObject.CreateInstance(GetType());
        instance.isInstance = true;
        instance.Initialize(this);
        return instance;
    }
    public override bool GroupUpdate()
    {
        if (spawnedCount != enemiesCount)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                timer = spawnEnemiesInterval;
                Vector2 point = path.points[0];
                GameObject enemyInstance = Instantiate(enemyPrefab, point, Quaternion.identity);
                enemyInstance.GetComponent<PathMoveComponent>().path = path;
                spawnedCount++;
            }
            return true;
        }
        return false;
    }
}
