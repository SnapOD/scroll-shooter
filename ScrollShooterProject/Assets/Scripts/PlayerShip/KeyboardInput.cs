using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IDirectionInput
{
    public Vector2 Direction { get { return direction; } }
    Vector2 direction;
    private void Update()
    {
        direction.x = Input.GetAxis("Horizontal");
        direction.y = Input.GetAxis("Vertical");
        if (direction.sqrMagnitude > 1)
            direction.Normalize();
    }
}
