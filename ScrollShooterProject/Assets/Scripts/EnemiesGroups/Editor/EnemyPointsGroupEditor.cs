using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(EnemyPointsGroup))]
public class EnemyPointsGroupEditor : Editor
{
    GUIContent moveDownButtonContent = new GUIContent("\u2193", "move down");
    GUIContent moveUpButtonContent = new GUIContent("\u2191", "move up");
    GUIContent deleteButtonContent = new GUIContent("-", "delete");
    GUIContent addButtonContent = new GUIContent("+", "add");
    GUILayoutOption miniButtonWidth = GUILayout.Width(20f);

    public override void OnInspectorGUI()
    {
        //serializedObject.Update();
        //ShowPointsArray_Inspector();

        //serializedObject.ApplyModifiedProperties();
    }

    void ShowPointsArray_Inspector() // отображение списка точек в инспекторе
    {
        SerializedProperty pathPoints = serializedObject.FindProperty("points");

        if (EditorGUILayout.PropertyField(pathPoints))
        {
            float lW = EditorGUIUtility.labelWidth;
            EditorGUIUtility.labelWidth = 30f;
            EditorGUI.indentLevel += 1;
            for (int i = 0; i < pathPoints.arraySize; i++)
            {
                SerializedProperty point = pathPoints.GetArrayElementAtIndex(i);

                EditorGUILayout.BeginHorizontal();
                //EditorGUILayout.PropertyField(point);
                EditorGUILayout.PropertyField(point, new GUIContent((i + 1).ToString()));
                //EditorGUILayout.PropertyField(point.FindPropertyRelative(""))
                ShowPointButtons_Inspector(i, pathPoints);
                EditorGUILayout.EndHorizontal();
            }
            EditorGUI.indentLevel -= 1;
            EditorGUIUtility.labelWidth = lW;
        }
    }
    void ShowPointButtons_Inspector(int index, SerializedProperty pathPoints) // отображение кнопок для каждой кнопки списка
    {
        if (GUILayout.Button(addButtonContent, EditorStyles.miniButtonLeft, miniButtonWidth))
        {
            pathPoints.InsertArrayElementAtIndex(index + 1);
        }
        if (pathPoints.arraySize > 2)
            if (GUILayout.Button(deleteButtonContent, EditorStyles.miniButtonMid, miniButtonWidth))
            {
                pathPoints.DeleteArrayElementAtIndex(index);
            }
        if (GUILayout.Button(moveUpButtonContent, EditorStyles.miniButtonMid, miniButtonWidth))
        {
            if (index > 0)
                pathPoints.MoveArrayElement(index, index - 1);
        }
        if (GUILayout.Button(moveDownButtonContent, EditorStyles.miniButtonRight, miniButtonWidth))
        {
            if (index < pathPoints.arraySize - 1)
                pathPoints.MoveArrayElement(index, index + 1);
        }
    }
}
