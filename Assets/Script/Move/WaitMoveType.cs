using UnityEngine;

//적의 움직임 패턴 기다리기
public class WaitMoveType : MoveType
{
    public float waitTime = 3f;

    public override Vector3[] GeneratePath(Transform[] points)
    {
        //움직임이 없음 null을 리턴하더라도 에러는 없음
        return new Vector3[0];
    }

    //그저 현재 위치를 리턴
    public override Vector3 GetPath(MoveObject moveObject)
    {
        moveObject.Index += Time.deltaTime;
        if (moveObject.Index >= waitTime)
            Completion(moveObject);
        return moveObject.transform.position;
    }
}