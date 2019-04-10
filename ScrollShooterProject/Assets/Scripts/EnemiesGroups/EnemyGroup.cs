using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EnemyGroup : ScriptableObject
{
    public abstract bool IsInstance { get; }
    public abstract EnemyGroup CreateInstance();
    public virtual bool GroupUpdate() { return true; }
}
