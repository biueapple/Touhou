using UnityEngine;

[System.Serializable]
public abstract class Phase
{
    protected Boss boss;
    [SerializeField]
    protected PatternData[] patternDatas;

    //¿òÁ÷ÀÓ
    protected MoveType[] moveTypes;

    protected Phase next;

    public float moveTime = 5;
    protected float moveTimer = 0;

    public virtual void Init(Boss boss, Phase next, MoveType[] moveTypes)
    {
        this.boss = boss;
        this.next = next;
        this.moveTypes = moveTypes;
    }
    public abstract void Enter();
    public abstract void Excute();
    public abstract void Exit();
}
