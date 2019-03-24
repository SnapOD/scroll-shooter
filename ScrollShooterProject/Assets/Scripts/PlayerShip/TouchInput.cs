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
            if (Input.touchCount == 0)
                return new Vector2();
            Touch touch = Input.GetTouch(0);
            Vector2 delta = touch.deltaPosition * touch.deltaTime;
            return delta * sensitivity;
        }
    }
}
