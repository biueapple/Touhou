using UnityEngine;

//���� �۵��� ������ �������ִ� Ŭ����
[CreateAssetMenu(menuName = "BulletPattern/Circular")]
public class CircularBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("������ �Ѿ� ���� ����")]
    private int bulletCount = 12;
    public int BulletCount => bulletCount;

    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new CircularPatternInstance(this, enemy);
    }
}

//���� �۵��ϴ� Ŭ����
public class CircularPatternInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly CircularBulletPattern pattern;

    public CircularPatternInstance(CircularBulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //���� �߻� (360���� ������Ʈ�� bulletCount ��ŭ �߻�)
    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            float angle = 360f * i / pattern.BulletCount;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}
