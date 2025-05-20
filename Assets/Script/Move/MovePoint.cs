using UnityEngine;

public class MovePoint : MonoBehaviour
{
    [SerializeField]
    private MoveTo moveTo;
    [SerializeField]
    private Transform[] point;
    public Transform[] Point { get { return point; } }
}
