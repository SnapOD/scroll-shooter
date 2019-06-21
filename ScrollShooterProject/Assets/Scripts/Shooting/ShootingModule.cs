using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShootingModule : ScriptableObject
{
    public abstract IShooting InitializeObject(GameObject gameObject);

}

