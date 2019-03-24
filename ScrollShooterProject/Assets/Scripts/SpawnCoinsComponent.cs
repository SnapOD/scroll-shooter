using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCoinsComponent : MonoBehaviour
{
    public int coins;
    public CoinController coinPrefab;
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
            CoinController inst = Instantiate(coinPrefab, transform.position, Quaternion.identity);
            inst.transform.localScale = Vector3.one * Random.Range(0.3f, 0.6f);
            inst.movement = Random.insideUnitCircle + Vector2.down * 3f/** 0.4f*/;
        }
    }
}
