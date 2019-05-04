using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class PointMoveComponent : MonoBehaviour
{
    public event Action<PointMoveComponent> MoveCompletedEvent;
    public Vector2 target;
    private Vector2 start;
    public float speed;
    float t;
    private void Start()
    {
        start = transform.position;
    }
    void Update()
    {
        if (t >= 1f)
            return;
        t += Time.deltaTime * speed;
        transform.position = Vector2.Lerp(start, target, t);
        if (t >= 1f && MoveCompletedEvent != null)
            MoveCompletedEvent(this);
    }
    public void Reset()
    {
        t = 0;
        start = transform.position;
    }
}
