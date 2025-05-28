using UnityEngine;

public class StraightMoveType : MoveType
{
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
