using UnityEngine;

//���� �۵��� ������ �������ִ� Ŭ����
[CreateAssetMenu(menuName = "BulletPattern/DotShowerChaos")]
public class DotShowerChaosPattern : BulletPattern
{
    //���� �۵��� Ŭ���� ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new DotShowerChaosInstance(this, enemy);
    }
}

//���� ������ �����ϴ� Ŭ����
public class DotShowerChaosInstance : PatternInstance
{
    private readonly DotShowerChaosPattern pattern;

    public DotShowerChaosInstance(DotShowerChaosPattern pattern, Enemy _)
    {
        this.pattern = pattern;
        //�� ������ ź�� ���� ���ϱ� Ȥ�� ���� 300�� �� ����
        ObjectPooling.Instance.Registration(pattern.BulletDatas[0].bulletId, pattern.BulletDatas[0].bulletPrefab);
    }

    //������ �������� DotBullet �߻�
    public override void Fire(Transform firePoint)
    {
        int angle = Random.Range(0, 360);
        Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
    }
}