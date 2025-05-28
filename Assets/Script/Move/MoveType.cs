using System.Collections.Generic;
using UnityEngine;

public abstract class MoveType : MonoBehaviour
{
    [SerializeField]
    private Transform[] point;
    [SerializeField] 
    protected Vector3[] path;
    public Vector3[] Path { get { return path; } }

    //�����ͷ� �۵�
    public void Initialized()
    {
        path = GeneratePath(point);
    }

    public abstract Vector3[] GeneratePath(Transform[] points);
    //��� path�� �̵��ߴٸ� Completionȣ��
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
            //���ϴ¸�ŭ �̵� �ߴٴ� ��
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
    //��� ��� �̵� �Ϸ�
    protected void Completion(MoveObject moveObject)
    {
        moveObject.SetNextPath();
    }
}
