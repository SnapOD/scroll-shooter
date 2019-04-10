using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class EnemyQueueObject : ScriptableObject
{
    [System.Serializable]
    public struct GroupSettings
    {
        public float time;
        public EnemyGroup group;
    }
    public GroupSettings[] groups;
}
