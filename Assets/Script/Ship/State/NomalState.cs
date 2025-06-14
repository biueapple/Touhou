using UnityEngine;

//�÷��̾ ����Ʈ�� ���� ���°� �ƴ� ����� ����
public class NomalState : IState
{
    //����� ���¿��� ����� collider
    private readonly Collider collider;
    public Collider Collider { get { return collider; } }
    //�÷��̾� ��ü
    private readonly Player_Ship ship;
    //�븻 �����϶� ����Ǵ� �ӵ�
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

    //�̰� �� ���������
    public void Switch()
    {
        ship.State = ship.ShiftState;
    }

    public void UpdateState()
    {
        
    }
}
