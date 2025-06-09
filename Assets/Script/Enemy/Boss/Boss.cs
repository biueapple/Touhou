using UnityEngine;

public abstract class Boss : Enemy
{
    public override float HP
    {
        get => hp;
        set => hp = value;
    }

    //state 들을 만들어 shooter를 변화시키자 결국 pattern instance만 바꾸면 되는거임
    //public BulletPattern[] patterns;
    //private PatternInstance[] instances;
    //움직임도 선택해서 바꿔줘야 함
    //Phase에서 전부 컨트롤 해야할 듯
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
