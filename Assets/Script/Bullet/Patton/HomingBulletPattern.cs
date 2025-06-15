using UnityEngine;

//���� �۵��� ������ �������ִ� Ŭ����
[CreateAssetMenu(menuName = "BulletPattern/Homing")]
public class HomingBulletPattern : BulletPattern
{
    //���� �۵��� Ŭ���� ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new HomingPatternInstance(this, enemy);
    }
}

//���� ������ �����ϴ� Ŭ����
public class HomingPatternInstance : PatternInstance
{
    private readonly BulletPattern pattern;

    public HomingPatternInstance(BulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //�÷��̾�� �߻�
    public override void Fire(Transform firePoint)
    {
        if (Player.Instance.Ship == null) return;

        //Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
        Vector3 dir = Player.Instance.RelativeDirection(firePoint);
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
    }
}