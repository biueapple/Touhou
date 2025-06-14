using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/PartCircle")]
public class PartCircleBulletPattern : BulletPattern
{
    [Header("�¿�� �߰��� �߻��� �Ѿ��� ����")]
    public int bulletCount;
    [Header("�Ѿ��� ����")]
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
        //�÷��̾ ���� �ѹ�
        Vector3 direction = (Player.Instance.Ship.transform.position - firePoint.position);
        BulletManager.Instance.FireBullet(firePoint.position, direction, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        Vector3 dir;
        //�� ������ ������
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
