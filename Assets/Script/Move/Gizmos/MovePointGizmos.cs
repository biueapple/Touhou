using UnityEngine;

//적의 이동경로를 gizmos로 그려주는 클래스
public class MovePointGizmos : MonoBehaviour
{
    //적이 어디서 어디로 가는지에 대한 데이터
    public MoveType data;

    private void OnDrawGizmos()
    {
        if (data == null || data.Path == null || data.Path.Length == 0)
            return;

        Gizmos.color = Color.cyan;

        // 선 그리기
        for (int i = 0; i < data.Path.Length - 1; i++)
            Gizmos.DrawLine(data.Path[i], data.Path[i + 1]);
    }
}
