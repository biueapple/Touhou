using UnityEngine;

public class MovePointGizmos : MonoBehaviour
{
    public MoveType data; // �����ͳ� �ڵ忡�� �� �����͸� �Ҵ�

    private void OnDrawGizmos()
    {
        if (data == null || data.Path == null || data.Path.Length == 0)
            return;

        Gizmos.color = Color.cyan;

        // �� �׸���
        for (int i = 0; i < data.Path.Length - 1; i++)
            Gizmos.DrawLine(transform.position + data.Path[i], transform.position + data.Path[i + 1]);
    }
}
