using System.Collections.Generic;
using UnityEngine;

//적의 움직임 패턴
public abstract class MoveType : MonoBehaviour
{
    //움직임의 포인트
    [SerializeField]
    private Transform[] point;
    public Transform[] Point { get { return point; } }
    //point를 기반으로 만들어진 이동경로
    [SerializeField] 
    protected Vector3[] path;
    public Vector3[] Path { get { return path; } }

    //에디터로 작동시키지 않았다면 시작할때 경로를 만들기
    private void Start()
    {
        if (path == null)
            path = GeneratePath(point);
    }

    //에디터로 작동
    public void Initialized()
    {
        path = GeneratePath(point);
    }

    //point를 기반으로 경로를 만들어줌
    public abstract Vector3[] GeneratePath(Transform[] points);

    //모든 path를 이동했다면 Completion호출
    public virtual Vector3 GetPath(MoveObject moveObject)
    {
        //목적지와 어느정도 가까워 졌다면 다음 인덱스로 (index는 moveObject가 가지고 있음 하나의 이동패턴을 여러 오브젝트가 사용할 수 있도록)
        if (Vector3.Distance(moveObject.transform.position, path[(int)moveObject.Index]) < 0.1f)
            moveObject.Index++;

        //모든 이동경로를 이동함
        if(path.Length <= moveObject.Index)
        {
            Completion(moveObject);
            return moveObject.transform.position;
        }
        return path[(int)moveObject.Index];
    }

    //모든 경로 이동 완료
    protected void Completion(MoveObject moveObject)
    {
        //다음 이동 패턴을 사용하여 이동
        moveObject.SetNextPath();
    }
}
