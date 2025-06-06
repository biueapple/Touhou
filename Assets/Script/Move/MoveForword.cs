using UnityEngine;

//적의 움직임 패턴 직선 움직임
public class StraightMoveType : MoveType
{
    //point를 기반으로 경로를 만들어 리턴
    public override Vector3[] GeneratePath(Transform[] points)
    {
        Vector3[] path = new Vector3[points.Length];
        for (int i = 0; i < points.Length; i++)
        {
            path[i] = points[i].position;
        }
        return path;
    }
}
