using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/TargetBeamPattern")]
public class TargetBeamPattern : BulletPattern
{
    [Header("�߻��� ������ ����")]
    public int count;
    [Header("������ ������ ��")]
    public float term;
    //������ ����
    public override PatternInstance CreateInstance()
    {
        return new TargetBeamInstance(this);
    }
}

//���� �۵��ϴ� Ŭ����
public class TargetBeamInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly TargetBeamPattern pattern;

    public TargetBeamInstance(TargetBeamPattern pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        Player.Instance.StartCoroutine(FireSequence(firePoint));
    }

    private IEnumerator FireSequence(Transform firePoint)
    {
        for(int i = 0; i < pattern.count; i++)
        {
            Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(firePoint.position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2;

            yield return new WaitForSeconds(pattern.term);
        }
    }
}
