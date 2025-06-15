using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/PartCircle")]
public class PartCircleBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("�¿�� �߰��� �߻��� �Ѿ��� ����")]
    private int bulletCount;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("�Ѿ��� ����")]
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
        //�÷��̾ ���� �ѹ�
        Vector3 direction = (Player.Instance.Ship.transform.position - firePoint.position);
        BulletManager.Instance.FireBullet(firePoint.position, direction, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        Vector3 dir;
        //�� ������ ������
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
