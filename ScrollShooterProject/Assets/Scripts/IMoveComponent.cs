using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IMoveComponent
{
    event Action MoveCompletedEvent;
    void StartMove();
    void StopMove();
}
