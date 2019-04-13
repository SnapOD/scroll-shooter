using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointMoveComponent : MonoBehaviour
{
    public Vector2 target;
    public float speed;

    float t;
    void Update()
    {
        if (t >= 1f)
            return;
        t += Time.deltaTime * speed;
        transform.position = Vector2.Lerp(transform.position, target, t);
    }
}
