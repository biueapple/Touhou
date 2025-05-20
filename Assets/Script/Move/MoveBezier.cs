using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Bezier", menuName = "Move/Bezier")]
public class MoveBezier : MoveTo
{
    public override Vector3[] Init(Vector3[] points)
    {        
        if (points.Length == 0)
            return points;
        List<Vector3> list = new();

        float distance = 0;

        for (int i = 0; i < points.Length - 1; i++)
            distance += Vector3.Distance(points[i], points[i + 1]);

        float t = 0;

        Vector3 vector = points[0];
        while(t <= 1)
        {
            for (int i = 0; i < points.Length; i++)
            {
                vector += Vector3.Lerp(vector, points[i], t);
            }
            t += distance / 1;
            list.Add(vector);
        }
        return list.ToArray();
    }
}
