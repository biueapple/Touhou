using UnityEngine;

//���� �۵��� ������ �������ִ� Ŭ����
[CreateAssetMenu(menuName = "BulletPattern/Homing")]
public class HomingBulletPattern : BulletPattern
{
    //���� �۵��� Ŭ���� ����
    public override PatternInstance CreateInstance()
    {
        return new HomingPatternInstance();
    }
}

//���� ������ �����ϴ� Ŭ����
public class HomingPatternInstance : PatternInstance
{
    //�÷��̾�� �߻�
    public override void Fire(Transform firePoint, int hash)
    {
        if (Player.Instance.Ship == null) return;

        Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, 2, hash);
    }
}