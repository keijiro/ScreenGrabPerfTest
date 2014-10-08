using UnityEngine;
using UnityEditor;
using System.Collections;

[CustomEditor(typeof(SimpleChromaticAberration)), CanEditMultipleObjects]
public class SimpleChromaticAberrationEditor : Editor
{
    SerializedProperty propAmount;

    void OnEnable()
    {
        propAmount = serializedObject.FindProperty("amount");
    }

    public override void OnInspectorGUI()
    {
        serializedObject.Update();

        EditorGUILayout.Slider(propAmount, 0.0f, 10.0f);

        serializedObject.ApplyModifiedProperties();
    }
}
