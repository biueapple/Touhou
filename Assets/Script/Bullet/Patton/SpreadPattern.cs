using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpreadPattern")]
public class SpreadPattern : BulletPattern
{
    [SerializeField]
    [Header("�������� �߻��ϴ� ź�� ����")]
    private int bulletCount = 4;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("ź ������ ������")]
    private float delay = 0.1f;
    public float Delay => delay;

    [SerializeField]
    [Header("ź ������ ����")]
    private float angle = 2;
    public float Angle => angle;

    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new SpreadPatternInstance(this, enemy);
    }
}

//���� �۵��ϴ� Ŭ����
public class SpreadPatternInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly SpreadPattern pattern;
    private readonly Enemy enemy;

    public SpreadPatternInstance(SpreadPattern pattern, Enemy enemy)
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
        Vector3 playerPos = Player.Instance.Ship.transform.position;
        Vector3 baseDir = (playerPos - firePoint.position).normalized;
        // �������� ������ ����
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 spreadDir = Quaternion.Euler(0, 0, -pattern.Angle * i) * baseDir;
            BulletManager.Instance.FireBullet(firePoint.position, spreadDir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            yield return new WaitForSeconds(pattern.Delay);
        }

        // ���������� ������ ����
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 spreadDir = Quaternion.Euler(0, 0, pattern.Angle * i) * baseDir;
            BulletManager.Instance.FireBullet(firePoint.position, spreadDir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            yield return new WaitForSeconds(pattern.Delay);
        }
    }
}

