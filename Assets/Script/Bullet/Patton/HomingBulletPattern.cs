using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/Homing")]
public class HomingBulletPattern : BulletPattern
{
    //실제 작동할 클래스 생성
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new HomingPatternInstance(this, enemy);
    }
}

//실제 패턴을 생성하는 클래스
public class HomingPatternInstance : PatternInstance
{
    private readonly BulletPattern pattern;

    public HomingPatternInstance(BulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //플레이어에게 발사
    public override void Fire(Transform firePoint)
    {
        if (Player.Instance.Ship == null) return;

        //Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
        Vector3 dir = Player.Instance.RelativeDirection(firePoint);
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
    }
}