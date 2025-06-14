using UnityEngine;

//플레이어가 쉬프트를 누른 상태가 아닌 평범한 상태
public class NomalState : IState
{
    //평범한 상태에서 적용될 collider
    private readonly Collider collider;
    public Collider Collider { get { return collider; } }
    //플레이어 기체
    private readonly Player_Ship ship;
    //노말 상태일때 적용되는 속도
    private readonly float speed = 2;

    public NomalState(Collider collider, GameObject center, Player_Ship ship)
    {
        this.collider = collider;
        this.ship = ship;
        speed = 3.5f;
    }

    public void EnterState()
    {
        collider.enabled = true;
        ship.Move.Speed = speed;
    }

    public void ExitState()
    {
        collider.enabled = false;
    }

    //이건 왜 만들었더라
    public void Switch()
    {
        ship.State = ship.ShiftState;
    }

    public void UpdateState()
    {
        
    }
}
