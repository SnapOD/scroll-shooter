using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CoinsText : MonoBehaviour
{
    Text coinsText;
    CoinsController coinsController;
    void Start()
    {
        coinsText = GetComponent<Text>();
        coinsController = FindObjectOfType<CoinsController>();
        coinsController.CoinsChangedEvent += CoinsController_CoinsChangedEvent;
        coinsText.text = 0.ToString();
    }
    private void CoinsController_CoinsChangedEvent(int obj)
    {
        coinsText.text = obj.ToString();
    }
}
