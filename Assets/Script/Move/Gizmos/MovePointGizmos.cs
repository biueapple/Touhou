using UnityEngine;

//���� �̵���θ� gizmos�� �׷��ִ� Ŭ����
public class MovePointGizmos : MonoBehaviour
{
    //���� ��� ���� �������� ���� ������
    public MoveType data;

    private void OnDrawGizmos()
    {
        if (data == null || data.Path == null || data.Path.Length == 0)
            return;

        Gizmos.color = Color.cyan;

        // �� �׸���
        for (int i = 0; i < data.Path.Length - 1; i++)
            Gizmos.DrawLine(data.Path[i], data.Path[i + 1]);
    }
}
