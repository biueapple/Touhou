using UnityEngine;

//둥글게 발사하는 패턴
[CreateAssetMenu(menuName = "BulletPattern/Spiral")]
public class SpiralBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("한 프레임에에 발사할 총알의 갯수")]
    private int bulletCount = 5;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("한 프레임에 움직일 다음 각도")]
    private float angleStep = 10f;
    public float AngleStep => angleStep;

    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new SpiralPatternInstance(this, enemy);
    }
}

public class SpiralPatternInstance : PatternInstance
{
    private readonly SpiralBulletPattern pattern;
    //현재 각도
    private float currentAngle = 0f;

    public SpiralPatternInstance(SpiralBulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            float angle = currentAngle + (pattern.AngleStep * i);
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;   
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }

        currentAngle += pattern.AngleStep;
    }
}