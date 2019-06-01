using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class PathMoveComponent : MonoBehaviour
{
    public event Action<PathMoveComponent> PathPassedEvent;
    public PathScriptableObject path;
    public float speed = 5f;
    int targetIndex = 1;
    Vector3 moveDir;
    private void Start()
    {
        transform.position = path.points[0];
        moveDir = (Vector3)path.points[1] - transform.position;
        moveDir.Normalize();
    }
    void Update()
    {
        if (targetIndex == -1)
            return;
        if (targetIndex < path.points.Length)
        {
            transform.position += moveDir * speed * Time.deltaTime;
            Vector2 dirToTarget = path.points[targetIndex] - (Vector2)transform.position;
            float dot = Vector2.Dot(moveDir, dirToTarget);
            if (dot <= 0)
            {
                targetIndex++;
                if (targetIndex == path.points.Length)
                {
                    targetIndex = -1;
                    if (PathPassedEvent != null)
                        PathPassedEvent(this);
                    return;
                }
                moveDir = (Vector3)path.points[targetIndex] - transform.position;
                moveDir.Normalize();

            }
        }
    }
}
