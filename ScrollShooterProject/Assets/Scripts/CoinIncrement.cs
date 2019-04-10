using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinIncrement : MonoBehaviour
{
    CoinsController coinsController;
    public ObjectCollectorComponent objectCollector;
    void Start()
    {
        coinsController = FindObjectOfType<CoinsController>();
        objectCollector = GetComponent<ObjectCollectorComponent>();
        objectCollector.ObjectsCollectedEvent += ObjectCollector_ObjectsCollectedEvent;
    }
    private void ObjectCollector_ObjectsCollectedEvent(Collider2D[] arg1, int arg2)
    {
        coinsController.AddCoins(arg2);
        for (int i = 0; i < arg2; i++)
        {
            Destroy(arg1[i].gameObject);
        }
    }
}
