using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/Boss1")]
public class BossPattern_1 : BulletPattern
{
    //한 방향으로 발사할 총알의 갯수
    public int bulletCount = 5;
    //한 프레임에 움직일 다음 각도
    public float angleStep = 10f;

    public override PatternInstance CreateInstance()
    {
        return new BossPatternInstance(this);
    }
}

public class BossPatternInstance : PatternInstance
{
    private BossPattern_1 pattern;
    //현재 발사한 총알 갯수
    private int bullet = 0;
    //현재 각도
    private float currentAngle = 0f;
    //방향
    private int side = 1;   

    public BossPatternInstance(BossPattern_1 pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        Vector3 dir = Quaternion.Euler(0, 0, currentAngle * side) * Player.Instance.RelativeDirection(firePoint);
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

        bullet++;
        currentAngle += pattern.angleStep;
        if (bullet >= pattern.bulletCount)
        {
            side *= -1;
            currentAngle = 0f;
            bullet = 0;
        }
    }
}