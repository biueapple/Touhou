using UnityEngine;

public class MovePointGizmos : MonoBehaviour
{
    public MoveType data; // 에디터나 코드에서 이 데이터를 할당

    private void OnDrawGizmos()
    {
        if (data == null || data.Path == null || data.Path.Length == 0)
            return;

        Gizmos.color = Color.cyan;

        // 선 그리기
        for (int i = 0; i < data.Path.Length - 1; i++)
            Gizmos.DrawLine(transform.position + data.Path[i], transform.position + data.Path[i + 1]);
    }
}
