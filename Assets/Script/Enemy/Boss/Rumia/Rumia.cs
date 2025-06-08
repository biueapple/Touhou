using UnityEngine;

public class Rumia : Enemy
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
