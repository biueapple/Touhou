using UnityEngine;
using UnityEditor;

[CanEditMultipleObjects]
[CustomEditor(typeof(MoveType), true)]
public class MovePointEditor : Editor
{
    public override void OnInspectorGUI()
    {
        // ���� �ν����� �׸���
        DrawDefaultInspector();

        // ��ư �����
        MoveType example = (MoveType)target;
        if (GUILayout.Button("Initialized"))
        {
            example.Initialized();
        }
    }
}
