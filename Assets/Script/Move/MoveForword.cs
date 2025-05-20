using UnityEngine;

[CreateAssetMenu(fileName = "Forword", menuName = "Move/Forword")]
public class MoveForword : MoveTo
{
    public override Vector3[] Init(Vector3[] points)
    {
        return points;        
    }
}
