using UnityEngine;

//둥글게 발사하는 패턴
[CreateAssetMenu(menuName = "BulletPattern/Spiral")]
public class SpiralBulletPattern : BulletPattern
{
    //한 프레임에에 발사할 총알의 갯수
    public int bulletCount = 5;
    //한 프레임에 움직일 다음 각도
    public float angleStep = 10f;

    public override PatternInstance CreateInstance()
    {
        return new SpiralPatternInstance(this);
    }
}

public class SpiralPatternInstance : PatternInstance
{
    private SpiralBulletPattern pattern;
    //현재 각도
    private float currentAngle = 0f;

    public SpiralPatternInstance(SpiralBulletPattern pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint, int hash)
    {
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            float angle = currentAngle + (pattern.angleStep * i);
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, 2, hash);
        }

        currentAngle += pattern.angleStep;
    }
}