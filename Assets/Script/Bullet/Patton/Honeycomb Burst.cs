using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/HoneycombBurst")]
public class HoneycombBurstPattern : BulletPattern
{
    //몇발을 발사할지
    public int count;

    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new HoneycombBurstInstance(this, enemy);
    }
}

//실제 작동하는 클래스
public class HoneycombBurstInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly HoneycombBurstPattern pattern;

    public HoneycombBurstInstance(HoneycombBurstPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //패턴 발사 (360도로 오브젝트의 bulletCount 만큼 발사)
    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.count; i++)
        {
            float angle = 360f * i / pattern.count;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}
