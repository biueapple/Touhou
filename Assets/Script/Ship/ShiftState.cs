using UnityEngine;

public class ShiftState : IState
{
    //적용되는 콜라이더
    private readonly Collider collider;
    //쉬프트를 누르면 가운데 빨간 점이 생겨야 해서
    private readonly GameObject center;
    //플레이어 기체
    private readonly Player_Ship ship;
    //감속 상태일때 적용되는 속도
    private readonly float speed = 1;

    public ShiftState(Collider collider, GameObject center, Player_Ship ship)
    {
        this.collider = collider;
        this.center = center;
        this.ship = ship;
        speed = 1;
    }

    //콜라이더와 속도 빨간점에 대한 코드들
    public void EnterState()
    {
        collider.enabled = true;
        center.SetActive(true);
        ship.Move.Speed = speed;
    }

    public void ExitState()
    {
        collider.enabled = false;
        center.SetActive(false);
    }

    public void Switch()
    {
        ship.State = ship.NomalState;
    }

    public void UpdateState()
    {
        
    }
}
