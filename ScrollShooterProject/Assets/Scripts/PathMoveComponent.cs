using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathMoveComponent : MonoBehaviour
{
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
        if (targetIndex < path.points.Length)
        {
            transform.position += moveDir * speed * Time.deltaTime;
            Vector2 dirToTarget = path.points[targetIndex] - (Vector2)transform.position;
            float dot = Vector2.Dot(moveDir, dirToTarget);
            if (dot <= 0)
            {
                targetIndex++;
                if (targetIndex == path.points.Length)
                    return;
                moveDir = (Vector3)path.points[targetIndex] - transform.position;
                moveDir.Normalize();
            }
        }
    }
}
