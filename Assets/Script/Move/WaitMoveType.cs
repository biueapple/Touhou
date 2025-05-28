using UnityEngine;

public class WaitMoveType : MoveType
{
    public float waitTime = 3f;

    public override Vector3[] GeneratePath(Transform[] points)
    {
        //// ù ��ġ�� �ӹ��� �ð��� �Ҹ��ϴ� ��� ��ȯ
        //Vector3[] path = new Vector3[Mathf.CeilToInt(waitTime * 60)];
        //Vector3 stay = points[0].position;
        //for (int i = 0; i < path.Length; i++)
        //{
        //    path[i] = stay;
        //}
        //return path;
        return new Vector3[0];
    }

    public override Vector3 GetPath(MoveObject moveObject)
    {
        moveObject.Index += Time.deltaTime;
        if (moveObject.Index >= waitTime)
            Completion(moveObject);
        return moveObject.transform.position;
    }
}