using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/Homing")]
public class HomingBulletPattern : BulletPattern
{
    //실제 작동할 클래스 생성
    public override PatternInstance CreateInstance()
    {
        return new HomingPatternInstance();
    }
}

//실제 패턴을 생성하는 클래스
public class HomingPatternInstance : PatternInstance
{
    //플레이어에게 발사
    public override void Fire(Transform firePoint, int hash)
    {
        if (Player.Instance.Ship == null) return;

        Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, 2, hash);
    }
}