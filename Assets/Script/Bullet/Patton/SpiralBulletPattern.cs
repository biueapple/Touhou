using UnityEngine;

//�ձ۰� �߻��ϴ� ����
[CreateAssetMenu(menuName = "BulletPattern/Spiral")]
public class SpiralBulletPattern : BulletPattern
{
    //�� �����ӿ��� �߻��� �Ѿ��� ����
    public int bulletCount = 5;
    //�� �����ӿ� ������ ���� ����
    public float angleStep = 10f;

    public override PatternInstance CreateInstance()
    {
        return new SpiralPatternInstance(this);
    }
}

public class SpiralPatternInstance : PatternInstance
{
    private SpiralBulletPattern pattern;
    //���� ����
    private float currentAngle = 0f;

    public SpiralPatternInstance(SpiralBulletPattern pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint, int hash)
    {
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            float angle = currentAngle + (pattern.angleStep * i);
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, 2, hash);
        }

        currentAngle += pattern.angleStep;
    }
}