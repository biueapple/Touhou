using UnityEngine;

public class ShiftState : IState
{
    private readonly Collider collider;
    private readonly GameObject center;
    private readonly Player_Ship ship;

    public ShiftState(Collider collider, GameObject center, Player_Ship ship)
    {
        this.collider = collider;
        this.center = center;
        this.ship = ship;
    }

    public void EnterState()
    {
        collider.enabled = true;
        center.SetActive(true);
        ship.Move.Speed = 1;
    }

    public void ExitState()
    {
        collider.enabled = false;
    }

    public void Switch()
    {
        ship.State = ship.NomalState;
    }

    public void UpdateState()
    {
        
    }
}
