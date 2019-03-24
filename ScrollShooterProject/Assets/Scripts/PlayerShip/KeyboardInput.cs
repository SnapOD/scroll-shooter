using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyboardInput : MonoBehaviour, IInputSource
{
    public Vector2 Direction { get { return new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")); } }
}
