using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FrameRateComponent : MonoBehaviour
{
    public Text frText;
    public int count = 10;
    int c;
    float t;
    float fr;
    private void Awake()
    {
        Application.targetFrameRate = 60;
    }
    void Update()
    {
        c++;
        t += Time.deltaTime;
        if (c == count)
        {
            fr = 1f / (t / c);
            frText.text = fr.ToString("N2");
            c = 0;
            t = 0;
        }
        
    }
}
