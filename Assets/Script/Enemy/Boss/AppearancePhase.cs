using UnityEngine;

[System.Serializable]
public class AppearancePhase : Phase
{
    private MoveObject moveObject;
    public override void Enter()
    {
        moveObject = boss.MoveObject;
        moveObject.moveTypes = moveTypes;
    }

    public override void Excute()
    {
        if (moveObject.Arrival())
        {
            boss.Now = next;
        }
    }

    public override void Exit()
    {

    }
}
