using UnityEngine;

//���� ������ ���� ��ٸ���
public class WaitMoveType : MoveType
{
    public float waitTime = 3f;

    public override Vector3[] GeneratePath(Transform[] points)
    {
        //�������� ���� null�� �����ϴ��� ������ ����
        return new Vector3[0];
    }

    //���� ���� ��ġ�� ����
    public override Vector3 GetPath(MoveObject moveObject)
    {
        moveObject.Index += Time.deltaTime;
        if (moveObject.Index >= waitTime)
            Completion(moveObject);
        return moveObject.transform.position;
    }
}