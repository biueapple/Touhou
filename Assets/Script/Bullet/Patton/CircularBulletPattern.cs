using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/Circular")]
public class CircularBulletPattern : BulletPattern
{
    //패턴의 총알 생산 갯수
    public int bulletCount = 12;

    //패턴을 생산
    public override PatternInstance CreateInstance()
    {
        return new CircularPatternInstance(this);
    }
}

//실제 작동하는 클래스
public class CircularPatternInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private CircularBulletPattern pattern;

    public CircularPatternInstance(CircularBulletPattern pattern)
    {
        this.pattern = pattern;
    }

    //패턴 발사 (360도로 오브젝트의 bulletCount 만큼 발사)
    public override void Fire(Transform firePoint, int hash)
    {
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            float angle = 360f * i / pattern.bulletCount;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, 2, hash);
        }
    }
}
