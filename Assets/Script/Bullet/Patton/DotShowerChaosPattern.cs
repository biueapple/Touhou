using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/DotShowerChaos")]
public class DotShowerChaosPattern : BulletPattern
{
    //실제 작동할 클래스 생성
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new DotShowerChaosInstance(this, enemy);
    }
}

//실제 패턴을 생성하는 클래스
public class DotShowerChaosInstance : PatternInstance
{
    private readonly DotShowerChaosPattern pattern;

    public DotShowerChaosInstance(DotShowerChaosPattern pattern, Enemy _)
    {
        this.pattern = pattern;
        //이 패턴은 탄을 많이 쓰니까 혹시 몰라서 300개 더 생산
        ObjectPooling.Instance.Registration(pattern.BulletDatas[0].bulletId, pattern.BulletDatas[0].bulletPrefab);
    }

    //무작위 방향으로 DotBullet 발사
    public override void Fire(Transform firePoint)
    {
        int angle = Random.Range(0, 360);
        Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
    }
}