using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpreadPattern")]
public class SpreadPattern : BulletPattern
{
    [Header("�������� �߻��ϴ� ź�� ����")]
    public int bulletCount = 4;
    [Header("ź ������ ������")]
    public float delay = 0.1f;
    [Header("ź ������ ����")]
    public float angle = 2;

    //������ ����
    public override PatternInstance CreateInstance()
    {
        return new SpreadPatternInstance(this);
    }
}

//���� �۵��ϴ� Ŭ����
public class SpreadPatternInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly SpreadPattern pattern;

    public SpreadPatternInstance(SpreadPattern pattern)
    {
        this.pattern = pattern;
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
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            Vector3 spreadDir = Quaternion.Euler(0, 0, -pattern.angle * i) * baseDir;
            BulletManager.Instance.FireBullet(firePoint.position, spreadDir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            yield return new WaitForSeconds(pattern.delay);
        }

        // ���������� ������ ����
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            Vector3 spreadDir = Quaternion.Euler(0, 0, pattern.angle * i) * baseDir;
            BulletManager.Instance.FireBullet(firePoint.position, spreadDir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            yield return new WaitForSeconds(pattern.delay);
        }
    }
}

