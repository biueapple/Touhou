using UnityEngine;

public abstract class Boss : Enemy
{
    [SerializeField]
    protected float maxHP = 1000;
    public float MaxHP { get => maxHP; }

    public override float HP
    {
        get => hp;
        set => hp = value;
    }

    //�ʱ� ����
    [SerializeField]
    protected AppearancePhase appearancePhase;

    //���� ����
    protected Phase now;
    public Phase Now { get { return now; } set { now?.Exit(); now = value; now?.Enter(); } }


    //������ bulletShooter�� ������� �ʰ� ���������� ����ϴ°� ���ؼ� �׷��� �ϴ��� 
    //Phase �� Excute���� ������
    private void Update()
    {
        now?.Excute();
    }
}
