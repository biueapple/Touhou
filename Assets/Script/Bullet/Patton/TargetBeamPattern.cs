using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/TargetBeamPattern")]
public class TargetBeamPattern : BulletPattern
{
    [SerializeField]
    [Header("�߻��� ������ ����")]
    private int count;
    public int Count => count;

    [SerializeField]
    [Header("������ ������ ��")]
    private float term;
    public float Term => term;

    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new TargetBeamInstance(this, enemy);
    }
}

//���� �۵��ϴ� Ŭ����
public class TargetBeamInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly TargetBeamPattern pattern;
    private readonly Enemy enemy;

    public TargetBeamInstance(TargetBeamPattern pattern, Enemy enemy)
    {
        this.pattern = pattern;
        this.enemy = enemy;
    }

    public override void Fire(Transform firePoint)
    {
        Player.Instance.StartCoroutine(FireSequence(firePoint));
    }

    private IEnumerator FireSequence(Transform firePoint)
    {
        for(int i = 0; i < pattern.Count; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(firePoint.position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2;

            yield return new WaitForSeconds(pattern.Term);
        }
    }
}
