using UnityEngine;

public abstract class BulletPattern : ScriptableObject
{
    [SerializeField]
    protected BulletData[] bulletDatas;
    public BulletData[] BulletDatas { get { return bulletDatas; } }
    [SerializeField]
    protected AnimationCurve speed;
    public AnimationCurve Speed { get { return speed; } }
    public abstract PatternInstance CreateInstance();
}
