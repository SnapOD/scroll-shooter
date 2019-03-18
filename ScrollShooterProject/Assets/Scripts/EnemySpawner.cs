using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public float yPosition = 10f;
    public float xRange = 10f;
    public float interval = 2f;
    public GameObject enemyPrefab;

    Coroutine inst;
    public void StartSpawn()
    {
        inst = StartCoroutine(SpawnCoroutine());
    }
    public void StopSpawn()
    {
        StopCoroutine(inst);
        inst = null;
    }

    IEnumerator SpawnCoroutine()
    {
        while (true)
        {
            float xRandom = Random.Range(0, xRange) - xRange / 2;
            GameObject enemyInst = Instantiate(enemyPrefab, new Vector3(xRandom, yPosition), enemyPrefab.transform.rotation);
            yield return new WaitForSeconds(interval);
        }
    }
    private void OnDrawGizmosSelected()
    {
        Vector2 left = new Vector2(xRange / 2 - xRange, yPosition);
        Vector2 right = new Vector2(xRange / 2, yPosition);
        Gizmos.DrawLine(left, right);
    }

}
