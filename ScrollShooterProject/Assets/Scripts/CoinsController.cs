using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CoinsController : MonoBehaviour
{
    public event Action<int> CoinsChangedEvent;
    [SerializeField]
    int coins;
    public int Coins { get { return coins; } }
    public void AddCoins(int amount)
    {
        coins += amount;
        if (CoinsChangedEvent != null)
            CoinsChangedEvent(coins);
    }
}
