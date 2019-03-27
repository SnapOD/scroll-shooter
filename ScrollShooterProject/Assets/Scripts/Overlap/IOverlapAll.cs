using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

internal interface IOverlapAll
{
    event Action<Collider2D[]> OverlappedEvent;
}
