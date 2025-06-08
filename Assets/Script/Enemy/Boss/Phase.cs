using UnityEngine;

[System.Serializable]
public abstract class Phase
{
    protected Enemy boss;
    //패턴
    [SerializeField]
    protected BulletPattern[] bulletPatterns;
    [SerializeField]
    protected PatternInstance[] patternInstances;

    //움직임
    [SerializeField]
    protected MoveType[] moveTypes;

    public virtual void Init(Enemy boss)
    {
        this.boss = boss;
        for (int i = 0; i < bulletPatterns.Length; i++)
        {
            for (int j = 0; j < bulletPatterns[i].BulletDatas.Length; i++)
            {
                ObjectPooling.Instance.Registration(bulletPatterns[i].BulletDatas[j].bulletId, bulletPatterns[i].BulletDatas[j].bulletPrefab, 100);
            }
            patternInstances[i] = bulletPatterns[i].CreateInstance();
        }
    }
    public abstract void Enter();
    public abstract void Excute();
    public abstract void Exit();
}
