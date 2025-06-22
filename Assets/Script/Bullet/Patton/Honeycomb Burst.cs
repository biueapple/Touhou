using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/HoneycombBurst")]
public class HoneycombBurstPattern : BulletPattern
{
    //����� �߻�����
    public int count;

    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new HoneycombBurstInstance(this, enemy);
    }
}

//���� �۵��ϴ� Ŭ����
public class HoneycombBurstInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly HoneycombBurstPattern pattern;

    public HoneycombBurstInstance(HoneycombBurstPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //���� �߻� (360���� ������Ʈ�� bulletCount ��ŭ �߻�)
    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.count; i++)
        {
            float angle = 360f * i / pattern.count;
            Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}
