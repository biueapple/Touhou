using UnityEngine;

public class MoveObject : MonoBehaviour
{
    public MoveType[] movePoints;

    [SerializeField]
    private int currentPathIndex = 0;

    private ShipMove move;

    [SerializeField]
    private float index = 0;
    public float Index { get { return index; } set { index = value; } }
    public float Speed { get { return move.Speed; } }

    private void Start()
    {
        move = GetComponent<ShipMove>();
    }

    private void Update()
    {
        if (movePoints == null)
            return;
        if (currentPathIndex >= movePoints.Length)
            return;
        Vector3 newPosition = movePoints[currentPathIndex].GetPath(this);
        //Debug.Log(newPosition);
        Vector3 direction = (newPosition - transform.position);
        direction.z = 0f;
        //Debug.Log(direction);
        move.Velocity = direction;
        //if (currentPath == null || currentPath.Length == 0 || currentSegment >= movePoints.Length)
        //    return;

        //Vector3 target = currentPath[currentPathIndex];
        //Vector3 direction = (target - transform.position);
        //direction.z = 0f;

        //if (direction.magnitude < 0.1f)
        //{
        //    currentPathIndex++;
        //    if (currentPathIndex >= currentPath.Length)
        //    {
        //        currentSegment++;
        //        if (currentSegment >= movePoints.Length)
        //        {
        //            return;
        //        }
        //        else
        //        {
        //            SetNextPath();
        //        }
        //    }
        //}
        //move.Velocity = direction;
    }

    public void SetNextPath()
    {
        //MovePoint mp = movePoints[currentSegment];
        //currentPath = mp.moveType.GeneratePath(mp.points);
        //currentPathIndex = 0;
        currentPathIndex++;
        index = 0;
    }
}
