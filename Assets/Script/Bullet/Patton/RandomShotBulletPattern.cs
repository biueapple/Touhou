using UnityEngine;

//���� �۵��� ������ �������ִ� Ŭ����
[CreateAssetMenu(menuName = "BulletPattern/RandomShot")]
public class RandomShotBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("�ѹ��� �߻�� �Ѿ��� ����")]
    private int bulletCount = 10;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("�ִ� �ּ��� ���� ����")]
    private float spreadAngle = 60f;
    public float SpreadAngle => spreadAngle;
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new RandomPatternInstance(this, enemy);
    }
}

public class RandomPatternInstance : PatternInstance
{
    private readonly RandomShotBulletPattern pattern;

    public RandomPatternInstance(RandomShotBulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //�Ʒ� �������� ���� ���� �߻�
    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            float angle = Random.Range(-pattern.SpreadAngle / 2f, pattern.SpreadAngle / 2f);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.down;
            BulletManager.Instance.FireBullet(firePoint.position, direction, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}