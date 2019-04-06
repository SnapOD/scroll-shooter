using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Path")]
[System.Serializable]
public class PathScriptableObject : ScriptableObject
{
    public Vector2[] nodes;
    public Vector2[] points;
    public float spacing;
    public bool isClosed;
    public bool HasNodes { get { return nodes != null && nodes.Length > 0; } }

}
