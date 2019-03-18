using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class MoveComponent : MonoBehaviour
{
    public event Action MoveEvent;
    public void Move(Vector2 dir, float speed)
    {
        Vector3 offset = dir * speed * Time.deltaTime;
        transform.position += offset;
    }
}
