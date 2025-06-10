using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/Boss1")]
public class BossPattern_1 : BulletPattern
{
    //�� �������� �߻��� �Ѿ��� ����
    public int bulletCount = 5;
    //�� �����ӿ� ������ ���� ����
    public float angleStep = 10f;

    public override PatternInstance CreateInstance()
    {
        return new BossPatternInstance(this);
    }
}

public class BossPatternInstance : PatternInstance
{
    private BossPattern_1 pattern;
    //���� �߻��� �Ѿ� ����
    private int bullet = 0;
    //���� ����
    private float currentAngle = 0f;
    //����
    private int side = 1;   

    public BossPatternInstance(BossPattern_1 pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        Vector3 dir = Quaternion.Euler(0, 0, currentAngle * side) * Player.Instance.RelativeDirection(firePoint);
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

        bullet++;
        currentAngle += pattern.angleStep;
        if (bullet >= pattern.bulletCount)
        {
            side *= -1;
            currentAngle = 0f;
            bullet = 0;
        }
    }
}