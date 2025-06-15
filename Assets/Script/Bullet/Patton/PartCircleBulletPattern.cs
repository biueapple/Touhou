using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/PartCircle")]
public class PartCircleBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("좌우로 추가로 발사할 총알의 갯수")]
    private int bulletCount;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("총알의 간격")]
    private int angle;
    public int Angle => angle;

    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new PartCirclePatternInstance(this, enemy);
    }
}

public class PartCirclePatternInstance : PatternInstance
{
    private readonly PartCircleBulletPattern pattern;

    public PartCirclePatternInstance(PartCircleBulletPattern pattern, Enemy _)
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
        for (int i = 1; i < pattern.BulletCount + 1; i++)
        {
            float angle = i * pattern.Angle;
            dir = Quaternion.Euler(0, 0, angle) * direction;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            dir = Quaternion.Euler(0, 0, -angle) * direction;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}
