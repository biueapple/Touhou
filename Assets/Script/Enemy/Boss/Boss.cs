using UnityEngine;

public abstract class Boss : Enemy
{
    public override float HP
    {
        get => hp;
        set => hp = value;
    }

    //state ���� ����� shooter�� ��ȭ��Ű�� �ᱹ pattern instance�� �ٲٸ� �Ǵ°���
    //public BulletPattern[] patterns;
    //private PatternInstance[] instances;
    //�����ӵ� �����ؼ� �ٲ���� ��
    //Phase���� ���� ��Ʈ�� �ؾ��� ��
    [SerializeField]
    private AppearancePhase appearancePhase;
    [SerializeField]
    private Rumia_Phase_1 phase_1;
    //[SerializeField]
    //private Phase[] phases;

    private Phase now;
    public Phase Now { get { return now; } set { now?.Exit(); now = value; now?.Enter(); } }

    new protected void Start()
    {
        base.Start();
        appearancePhase.Init(this, phase_1, moveObject.moveTypes[0].ToArray());
        phase_1.Init(this, null, new MoveType[2] { moveObject.moveTypes[1], moveObject.moveTypes[2] });
        moveObject.moveTypes = null;

        Now = appearancePhase;
    }

    private void Update()
    {
        now?.Excute();
    }
}
