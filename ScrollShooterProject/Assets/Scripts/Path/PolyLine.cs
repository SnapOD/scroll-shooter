using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PolyLine : IPolyLine
{
    List<Vector2> nodes;
    bool isClosed;
    public int NodesCount { get { return nodes.Count; } }
    /// <summary>
    /// Создает экщемпляр линии из 3 точек
    /// </summary>
    public PolyLine()
    {
        Vector2 a = new Vector2(-0.5f, -0.5f);
        Vector2 b = new Vector2(0.5f, -0.5f);
        Vector2 c = new Vector2(0f, 0.5f);
        nodes = new List<Vector2>() { a, b, c };
    }
    public PolyLine(IEnumerable<Vector2> nodes) { this.nodes = new List<Vector2>(nodes); }
    public void AddNode(Vector2 value) { throw new System.NotImplementedException(); }
    public void InsertNode(int index, Vector2 value) { nodes.Insert(index, value); }
    public void RemoveNode(int index) { nodes.RemoveAt(index); }
    public void MoveNode(int index, Vector2 value) { nodes[index] = value; }
    public Vector2 GetNode(int index) { return nodes[index]; }
    public Vector2[] GetNodes() { Vector2[] nodes = new Vector2[this.nodes.Count]; this.nodes.CopyTo(nodes); return nodes; }
    public Vector2[] GetPath() { Vector2[] path = new Vector2[nodes.Count]; nodes.CopyTo(path); return path; }
    //public List<Vector2> GetEvenlySpacedPoints(float spacing) { throw new System.NotImplementedException(); }
}


