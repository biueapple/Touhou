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
        for (int i = 0; i < points.Length - 1; i += 2)
        {
            Vector3 p0 = points[i].position;
            Vector3 p1 = (i + 1 < points.Length) ? points[i + 1].position : p0;
            Vector3 p2 = (i + 2 < points.Length) ? points[i + 2].position : p1;

            for (int j = 0; j < resolution; j++)
            {
                float t = j / (float)resolution;
                Vector3 pos = Mathf.Pow(1 - t, 2) * p0 +
                              2 * (1 - t) * t * p1 +
                              Mathf.Pow(t, 2) * p2;
                path.Add(pos);
            }
        }

        return path.ToArray();
    }
}
