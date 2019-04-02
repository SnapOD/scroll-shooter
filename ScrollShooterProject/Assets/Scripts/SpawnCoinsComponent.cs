using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinsComponent : MonoBehaviour
{
    public int coins;
    public ObjectMovementComponent coinPrefab;
    HealthComponent healthComponent;
    ScoreContoller scoreContoller;
    // Use this for initialization
    void Start()
    {
        healthComponent = GetComponent<HealthComponent>();
        healthComponent.DeathEvent += HealthComponent_DeathEvent;
    }
    private void HealthComponent_DeathEvent()
    {
        for (int i = 0; i < coins; i++)
        {
            ObjectMovementComponent inst = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            inst.transform.localScale = Vector3.one * Random.Range(0.1f, 0.3f);
            inst.velocity = Random.insideUnitCircle + Vector2.down * 3f/** 0.4f*/;
        }
    }
}
