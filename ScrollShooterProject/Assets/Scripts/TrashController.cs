using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashController : MonoBehaviour
{
    public Vector2 velocity;
    public float angularVelocity;
    MoveComponent moveComponent;
    void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    private void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;
        transform.Rotate(0f, 0f, angularVelocity * Time.deltaTime);
    }
}
