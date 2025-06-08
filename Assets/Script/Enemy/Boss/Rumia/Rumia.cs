using UnityEngine;

public class Rumia : Enemy
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
    private Rumia_Phase_1 phase_1;
    //[SerializeField]
    //private Phase[] phases;

    private Phase now;
    public Phase Now { get { return now; } set { now?.Exit(); now = value; now?.Enter(); } }

    private void Start()
    {
        phase_1.Init(this);
    }

    private void Update()
    {
        now?.Excute();
    }
}
