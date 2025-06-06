using System.Collections.Generic;
using UnityEngine;

//���� ������ ����
public abstract class MoveType : MonoBehaviour
{
    //�������� ����Ʈ
    [SerializeField]
    private Transform[] point;
    public Transform[] Point { get { return point; } }
    //point�� ������� ������� �̵����
    [SerializeField] 
    protected Vector3[] path;
    public Vector3[] Path { get { return path; } }

    //�����ͷ� �۵���Ű�� �ʾҴٸ� �����Ҷ� ��θ� �����
    private void Start()
    {
        if (path == null)
            path = GeneratePath(point);
    }

    //�����ͷ� �۵�
    public void Initialized()
    {
        path = GeneratePath(point);
    }

    //point�� ������� ��θ� �������
    public abstract Vector3[] GeneratePath(Transform[] points);

    //��� path�� �̵��ߴٸ� Completionȣ��
    public virtual Vector3 GetPath(MoveObject moveObject)
    {
        //�������� ������� ����� ���ٸ� ���� �ε����� (index�� moveObject�� ������ ���� �ϳ��� �̵������� ���� ������Ʈ�� ����� �� �ֵ���)
        if (Vector3.Distance(moveObject.transform.position, path[(int)moveObject.Index]) < 0.1f)
            moveObject.Index++;

        //��� �̵���θ� �̵���
        if(path.Length <= moveObject.Index)
        {
            Completion(moveObject);
            return moveObject.transform.position;
        }
        return path[(int)moveObject.Index];
    }

    //��� ��� �̵� �Ϸ�
    protected void Completion(MoveObject moveObject)
    {
        //���� �̵� ������ ����Ͽ� �̵�
        moveObject.SetNextPath();
    }
}
