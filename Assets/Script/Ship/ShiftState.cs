using UnityEngine;

public class ShiftState : IState
{
    //����Ǵ� �ݶ��̴�
    private readonly Collider collider;
    //����Ʈ�� ������ ��� ���� ���� ���ܾ� �ؼ�
    private readonly GameObject center;
    //�÷��̾� ��ü
    private readonly Player_Ship ship;
    //���� �����϶� ����Ǵ� �ӵ�
    private readonly float speed = 1;

    public ShiftState(Collider collider, GameObject center, Player_Ship ship)
    {
        this.collider = collider;
        this.center = center;
        this.ship = ship;
        speed = 1;
    }

    //�ݶ��̴��� �ӵ� �������� ���� �ڵ��
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
