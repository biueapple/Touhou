using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/FlowerWilyPattern")]
public class FlowerWilyPattern : BulletPattern
{
    //�÷��̾ ���� �ﰢ�� ������� �߻�
    [SerializeField]
    [Header("�ﰢ���� ũ��")]
    private int size;
    public int Size => size;

    [SerializeField]
    [Header("ź ���� ������ ����")]
    private float interval;
    public float Interval => interval;

    [SerializeField]
    [Header("ź ������ ������")]
    private float delay;
    public float Delay => delay;

    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new FlowerWilyPatternInstance(this, enemy);
    }
}


public class FlowerWilyPatternInstance : PatternInstance
{
    private readonly FlowerWilyPattern pattern;
    private readonly Enemy enemy;

    public FlowerWilyPatternInstance(FlowerWilyPattern pattern, Enemy enemy)
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
        Vector3 dir = Player.Instance.RelativeDirection(firePoint); 
        Vector3 rightDir = Vector3.Cross(Vector3.forward, dir).normalized;

        BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        yield return new WaitForSeconds(pattern.Delay);

        for (int i = 1; i < pattern.Size + 1; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            BulletManager.Instance.FireBullet(firePoint.position + rightDir * (pattern.Interval * i), dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

            BulletManager.Instance.FireBullet(firePoint.position - rightDir * (pattern.Interval * i), dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

            yield return new WaitForSeconds(pattern.Delay);
        }
    }
}