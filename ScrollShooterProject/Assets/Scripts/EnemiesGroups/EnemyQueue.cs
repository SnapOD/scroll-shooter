using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu]
public class EnemyQueue : ScriptableObject
{
    [Serializable]
    public struct ItemSettins
    {
        public float time;
        public QueueItem item;
    }
    public ItemSettins[] items;
}
