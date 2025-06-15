using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/Circular")]
public class CircularBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("패턴의 총알 생산 갯수")]
    private int bulletCount = 12;
    public int BulletCount => bulletCount;

    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new CircularPatternInstance(this, enemy);
    }
}

//실제 작동하는 클래스
public class CircularPatternInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly CircularBulletPattern pattern;

    public CircularPatternInstance(CircularBulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //패턴 발사 (360도로 오브젝트의 bulletCount 만큼 발사)
    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            float angle = 360f * i / pattern.BulletCount;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}
