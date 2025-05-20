using UnityEngine;

public class NomalState : IState
{
    private readonly Collider collider;
    private readonly GameObject center;
    private readonly Player_Ship ship;

    public NomalState(Collider collider, GameObject center, Player_Ship ship)
    {
        this.collider = collider;
        this.center = center;
        this.ship = ship;
    }

    public void EnterState()
    {
        collider.enabled = true;
        center.SetActive(false);
        ship.Move.Speed = 2;
    }

    public void ExitState()
    {
        collider.enabled = false;
    }

    public void Switch()
    {
        ship.State = ship.ShiftState;
    }

    public void UpdateState()
    {
        
    }
}
