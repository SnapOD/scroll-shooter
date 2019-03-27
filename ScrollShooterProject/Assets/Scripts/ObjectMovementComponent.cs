using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMovementComponent : MonoBehaviour
{
    public Vector2 movement;
    void Update()
    {
        transform.Translate(movement * Time.deltaTime);
    }
}
