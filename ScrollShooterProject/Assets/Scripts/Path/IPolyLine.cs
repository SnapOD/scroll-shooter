using UnityEngine;

public interface IPolyLine
{
    int NodesCount { get; }
    void AddNode(Vector2 value);
    Vector2 GetNode(int index);
    Vector2[] GetNodes();
    Vector2[] GetPath();
    void InsertNode(int index, Vector2 value);
    void MoveNode(int index, Vector2 value);
    void RemoveNode(int index);
}