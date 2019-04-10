using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyQueueManager : MonoBehaviour
{
    public EnemyQueueObject source;

    float timer = 0;

    List<EnemyQueueObject.GroupSettings> groups;
    public List<EnemyGroup> instantiated;
    private void Start()
    {
        instantiated = new List<EnemyGroup>(source.groups.Length);
        groups = new List<EnemyQueueObject.GroupSettings>(source.groups.Length);
        groups.AddRange(source.groups);
    }
    private void Update()
    {
        timer += Time.deltaTime;
        for (int i = 0; i < groups.Count;)
        {
            if (timer >= groups[i].time)
            {
                instantiated.Add(groups[i].group.CreateInstance());
                groups.RemoveAt(i);
                continue;
            }
            i++;
        }

        for (int i = 0; i < instantiated.Count;)
        {
            bool result = instantiated[i].GroupUpdate();
            if (!result)
            {
                instantiated.RemoveAt(i);
                continue;
            }
            i++;
        }
    }
}
