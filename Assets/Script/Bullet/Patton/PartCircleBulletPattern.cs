using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/PartCircle")]
public class PartCircleBulletPattern : BulletPattern
{
    [Header("좌우로 추가로 발사할 총알의 갯수")]
    public int bulletCount;
    [Header("총알의 간격")]
    public int angle;

    public override PatternInstance CreateInstance()
    {
        return new PartCirclePatternInstance(this);
    }
}

public class PartCirclePatternInstance : PatternInstance
{
    private PartCircleBulletPattern pattern;

    public PartCirclePatternInstance(PartCircleBulletPattern pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        //플레이어를 향해 한발
        Vector3 direction = (Player.Instance.Ship.transform.position - firePoint.position);
        BulletManager.Instance.FireBullet(firePoint.position, direction, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        Vector3 dir;
        //그 주위로 여러발
        for (int i = 1; i < pattern.bulletCount + 1; i++)
        {
            float angle = i * pattern.angle;
            dir = Quaternion.Euler(0, 0, angle) * direction;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            dir = Quaternion.Euler(0, 0, -angle) * direction;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}
