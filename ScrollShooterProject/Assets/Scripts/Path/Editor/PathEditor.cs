using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System;

[CustomEditor(typeof(PathScriptableObject))]
public class PathEditor : Editor
{
    PolyLine polyLine; //Класс с методами управления линией
    PathScriptableObject path; //Класс для хранения построенного пути
    int selectedLineIndex = -1;
    int selectedNodeIndex = -1;
    private void OnEnable() // выполняется при выборе компонента, к которому прикреплено расширение
    {
        Debug.Log("OnEnable");
        SceneView.onSceneGUIDelegate += OnSceneGUI; // нужно, чтобы отслеживать работу со сценой в расширении, привязанном к ScriptableObject
        Undo.undoRedoPerformed += UndoRedoHandler;
        path = target as PathScriptableObject; // получили ссылку на построенный путь
        //Debug.Log(path.points.Length);
        if (path.HasNodes) // если у построенного пути есть информация о "узлах" маршрута
            polyLine = new PolyLine(path.nodes); // создаем управляющий экземпляр
        else // если узлов нет - создаем маршрут с нуля
            InitializePath();
    }
    private void OnDisable() // выполняется при снятии выбора (фокуса) с компонента
    {
        SceneView.onSceneGUIDelegate -= OnSceneGUI;
        Undo.undoRedoPerformed -= UndoRedoHandler;
    }
    private void UndoRedoHandler() // реакция на нажатие перемещение по истории undo/redo
    {
        //Repaint();
        polyLine = new PolyLine(path.nodes);
        UpdatePath();
    }
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();
    }
    private void OnSceneGUI(SceneView sceneView) // нажатия на кнопки мыши
    {
        CheckSelectedElements();

        DrawNodes(/*highlightHovered: true*/);
        DrawPolyLine(highlightHovered: selectedNodeIndex == -1);// подсвечиваем выбранную линию если нет выбранной ручки

        Event currentEvent = Event.current;

        if (selectedLineIndex != -1)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
            if (currentEvent.type == EventType.MouseDown)
                if (currentEvent.button == 0 && currentEvent.clickCount == 2)
                {
                    Vector2 mousePos = HandleUtility.GUIPointToWorldRay(currentEvent.mousePosition).origin;
                    Undo.RecordObject(path, "Insert new node");
                    polyLine.InsertNode(selectedLineIndex + 1, mousePos);
                    UpdatePath();
                }
        }
        if (selectedNodeIndex != -1)
        {
            HandleUtility.AddDefaultControl(GUIUtility.GetControlID(FocusType.Passive));
            if (currentEvent.type == EventType.MouseDown)
            {
                if (currentEvent.button == 1 && currentEvent.clickCount == 2 && polyLine.NodesCount > 2)
                {
                    Undo.RecordObject(path, "Remove node");
                    polyLine.RemoveNode(selectedNodeIndex);
                    UpdatePath();
                    //SceneView.RepaintAll();
                }
            }
        }
    }
    private void InitializePath() // создание пути с нуля
    {
        polyLine = new PolyLine();
        UpdatePath();
    }
    private void DrawPolyLine(bool highlightHovered = false) // отображает белую линию между узлами пути
    {
        for (int i = 0; i < path.nodes.Length - 1; i++)
        {
            if (highlightHovered && i == selectedLineIndex)
                Handles.color = Color.yellow;
            else Handles.color = Color.white;

            Handles.DrawAAPolyLine(5f, path.nodes[i], path.nodes[i + 1]);
        }
        Handles.color = Color.gray;
        if (path.isClosed)
            Handles.DrawAAPolyLine(5f, path.nodes[path.nodes.Length - 1], path.nodes[0]);

    }
    private void DrawNodes(bool highlightHovered = false) // отображает узлы, отвечает за их перемещение
    {
        EditorGUI.BeginChangeCheck();

        for (int i = 0; i < polyLine.NodesCount; i++)
        {
            if (highlightHovered && i == selectedNodeIndex)
                Handles.color = Color.yellow;
            else
                Handles.color = Color.white;

            Handles.CapFunction cap;
            if (i == polyLine.NodesCount - 1)
                cap = Handles.SphereHandleCap;
            else
                cap = Handles.SphereHandleCap;
            Quaternion rotation = Quaternion.identity;

            Vector2 nodePosition = polyLine.GetNode(i);

            Vector3 newPosition = Handles.FreeMoveHandle(nodePosition, rotation, 0.5f, Vector3.zero, cap);
            if (newPosition != (Vector3)nodePosition)
                polyLine.MoveNode(i, newPosition);
        }

        if (EditorGUI.EndChangeCheck())
        {
            //Debug.Log("EndChange");
            Undo.RecordObject(path, "Change node position");
            UpdatePath();
        }
    }
    private void CheckSelectedElements()// определяем индексы элементов пути под курсором
    {

        Event guiEvent = Event.current;
        Vector2 mousePos = HandleUtility.GUIPointToWorldRay(guiEvent.mousePosition).origin;

        float foundLineDistance = 20;
        int foundLineIndex = -1;
        for (int i = 0; i < path.nodes.Length - 1; i++)// ищем индекс линии
        {
            float distance = HandleUtility.DistanceToLine(path.nodes[i], path.nodes[i + 1]);
            if (distance < foundLineDistance)
            {
                foundLineDistance = distance;
                foundLineIndex = i;
            }
        }
        selectedLineIndex = foundLineIndex;

        float foundNodeDistance = 20;
        int foundNodeIndex = -1;
        for (int i = 0; i < path.nodes.Length; i++)// ищем индекс ручки
        {
            float distance = HandleUtility.DistanceToLine(path.nodes[i], path.nodes[i]);
            if (distance < foundNodeDistance)
            {
                foundNodeDistance = distance;
                foundNodeIndex = i;
            }
        }

        selectedNodeIndex = foundNodeIndex;
    }
    private void UpdatePath()
    {
        Debug.Log("UpdatePath");
        path.nodes = polyLine.GetNodes();
        path.points = polyLine.GetPath();
        EditorUtility.SetDirty(path); // исправило проблему с сериализацией массива
    }

}
