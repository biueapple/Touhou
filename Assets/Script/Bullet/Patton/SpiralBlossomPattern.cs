using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpiralBlossomPattern")]
public class SpiralBlossomPattern : BulletPattern
{
    [Header("1�ʿ� ������ ����")]
    public float spiralSpeed = 60f;
    [Header("���� ź�� �߻�Ǵ� ������")]
    public float fireRate = 0.1f;
    //������ ����
    public override PatternInstance CreateInstance()
    {
        return new SpiralBlossomInstance(this);
    }
}


//���� �۵��ϴ� Ŭ����
public class SpiralBlossomInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly SpiralBlossomPattern pattern;

    public SpiralBlossomInstance(SpiralBlossomPattern pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        Player.Instance.StartCoroutine(FireSequence(firePoint));
    }

    //���� ����
    private float angle = 0f;
    private IEnumerator FireSequence(Transform firePoint)
    {
        for (int wave = 0; wave < 30; wave++) // �� ���� ���� 30ȸ �߻�
        {
            for (int i = 0; i < 12; i++)
            {
                float theta = angle + (i * 30f);
                Vector3 dir = Quaternion.Euler(0, 0, theta) * Vector3.up;
                BulletManager.Instance.FireBullet(firePoint.position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            }

            angle += pattern.spiralSpeed * Time.deltaTime;
            yield return new WaitForSeconds(pattern.fireRate);
        }
    }
}

