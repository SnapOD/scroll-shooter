using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public interface IShooting
{
    event Action<IShooting, Component> ShotEvent;
    bool IsEnabled { get; set; }
}
