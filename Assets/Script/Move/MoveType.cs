using System.Collections.Generic;
using UnityEngine;

public abstract class MoveType : MonoBehaviour
{
    [SerializeField]
    private Transform[] point;
    [SerializeField] 
    protected Vector3[] path;
    public Vector3[] Path { get { return path; } }

    //에디터로 작동
    public void Initialized()
    {
        path = GeneratePath(point);
    }

    public abstract Vector3[] GeneratePath(Transform[] points);
    //모든 path를 이동했다면 Completion호출
    public virtual Vector3 GetPath(MoveObject moveObject)
    {
        float distance = moveObject.Speed * Time.deltaTime;
        Vector3 newPosition = moveObject.transform.position;
        while (distance > 0)
        {
            Vector3 position = newPosition;
            newPosition = Vector3.MoveTowards(position, path[(int)moveObject.Index], distance);
            float magnitude = (position - newPosition).magnitude;
            Debug.Log("magnitude " + magnitude + ", distance " + distance);
            //원하는만큼 이동 했다는 뜻
            if (distance > magnitude)
            {
                distance -= magnitude;
                moveObject.Index++;
            }
            
            if ((int)moveObject.Index >= path.Length)
            {
                Completion(moveObject);
                break;
            }
        }
        return newPosition;
    }
    //모든 경로 이동 완료
    protected void Completion(MoveObject moveObject)
    {
        moveObject.SetNextPath();
    }
}
