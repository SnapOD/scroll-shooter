using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    MoveComponent moveComponent;
    public Vector2 movement;
    void Start()
    {
        moveComponent = GetComponent<MoveComponent>();
    }
    void Update()
    {
        moveComponent.Move(movement, 1f);
    }
}
