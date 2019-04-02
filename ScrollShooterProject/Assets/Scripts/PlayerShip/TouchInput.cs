using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchInput : MonoBehaviour, IInputSource
{
    public float sensitivity = 1;
    public Vector2 Direction
    {
        get
        {
            if (Time.deltaTime == 0f)
                return Vector2.zero;

            if (Input.touchCount == 0)
                return new Vector2();
            Touch touch = Input.GetTouch(0);
            float screenMult = Screen.width / 1000f;
            Vector2 delta = touch.deltaPosition * screenMult / Time.deltaTime;
            return delta * sensitivity;
        }
    }
}
