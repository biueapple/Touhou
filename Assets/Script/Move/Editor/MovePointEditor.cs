using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(MoveType), true)]
public class MovePointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // 원래 인스펙터 그리기
        DrawDefaultInspector();

        // 버튼 만들기
        MoveType example = (MoveType)target;
        if (GUILayout.Button("Initialized"))
        {
            example.Initialized();
        }
    }
}
