using System.Collections.Generic;
using UnityEngine;

public class MoveBezier : MoveType
{
    public int resolution = 20;

    public override Vector3[] GeneratePath(Transform[] points)
    {
        if (points.Length < 2)
            return new Vector3[0];

        List<Vector3> path = new ();

        Vector3 p0 = points[0].position;
        Vector3 p1 = points[1].position;
        Vector3 p2 = points[2].position;
        Vector3 p3 = points[3].position;

        for (int j = 0; j <= resolution; j++)
        {
            float t = j / (float)resolution;
            Vector3 point = Mathf.Pow(1 - t, 3) * p0 +
                            3 * Mathf.Pow(1 - t, 2) * t * p1 +
                            3 * (1 - t) * Mathf.Pow(t, 2) * p2 +
                            Mathf.Pow(t, 3) * p3;
            path.Add(point);
        }

        return path.ToArray();
    }
}
