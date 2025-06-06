using UnityEngine;

//���� �۵��� ������ �������ִ� Ŭ����
[CreateAssetMenu(menuName = "BulletPattern/Circular")]
public class CircularBulletPattern : BulletPattern
{
    //������ �Ѿ� ���� ����
    public int bulletCount = 12;

    //������ ����
    public override PatternInstance CreateInstance()
    {
        return new CircularPatternInstance(this);
    }
}

//���� �۵��ϴ� Ŭ����
public class CircularPatternInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private CircularBulletPattern pattern;

    public CircularPatternInstance(CircularBulletPattern pattern)
    {
        this.pattern = pattern;
    }

    //���� �߻� (360���� ������Ʈ�� bulletCount ��ŭ �߻�)
    public override void Fire(Transform firePoint, int hash)
    {
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            float angle = 360f * i / pattern.bulletCount;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, 2, hash);
        }
    }
}
