using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LevelQueueManager : MonoBehaviour
{
    public event Action QueueOverEvent;
    public EnemyQueue source;
    float timer = 0;

    public List<EnemyQueue.ItemSettins> queueItems;
    public List<QueueItem> instantiatedItems;
    private void Start()
    {
        instantiatedItems = new List<QueueItem>(source.items.Length);
        queueItems = new List<EnemyQueue.ItemSettins>(source.items.Length);
        queueItems.AddRange(source.items);
    }
    private void Update()
    {
        if (queueItems.Count != 0)
        {
            timer += Time.deltaTime;
            for (int i = 0; i < queueItems.Count;)
            {
                if (timer >= queueItems[i].time)
                {
                    QueueItem itemInst = queueItems[i].item.CreateInstance();
                    itemInst.CompletedEvent += ItemInst_CompletedEvent;
                    queueItems.RemoveAt(i);
                    instantiatedItems.Add(itemInst);
                    itemInst.Run(this);
                    continue;
                }
                i++;
            }
        }
    }
    private void ItemInst_CompletedEvent(QueueItem obj)
    {
        instantiatedItems.Remove(obj);
        if (queueItems.Count == 0 && instantiatedItems.Count == 0)
            if (QueueOverEvent != null)
                QueueOverEvent();

    }
}
