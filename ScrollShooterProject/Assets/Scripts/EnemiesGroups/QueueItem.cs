using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class QueueItem : ScriptableObject
{
    public abstract event Action<QueueItem> CompletedEvent;
    public abstract QueueItem CreateInstance();
    public abstract void Run(MonoBehaviour monoBehaviour);

}
