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

    //초기 상태
    [SerializeField]
    protected AppearancePhase appearancePhase;

    //현재 상태
    protected Phase now;
    public Phase Now { get { return now; } set { now?.Exit(); now = value; now?.Enter(); } }


    //보스는 bulletShooter를 사용하지 않고 독자적으로 사용하는게 편해서 그렇게 하는중 
    //Phase 의 Excute에서 제어중
    private void Update()
    {
        now?.Excute();
    }
}
