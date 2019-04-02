using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementComponent : MonoBehaviour
{
    public Vector2 velocity;
    void Update()
    {
        transform.Translate(velocity * Time.deltaTime);
    }
}
