using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpiralBlossomPattern")]
public class SpiralBlossomPattern : BulletPattern
{
    [SerializeField]
    [Header("1�ʿ� ������ ����")]
    private float spiralSpeed = 60f;
    public float SpiralSpeed => spiralSpeed;

    [SerializeField]
    [Header("���� ź�� �߻�Ǵ� ������")]
    private float fireRate = 0.1f;
    public float FireRate => fireRate;

    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new SpiralBlossomInstance(this, enemy);
    }
}


//���� �۵��ϴ� Ŭ����
public class SpiralBlossomInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly SpiralBlossomPattern pattern;
    private readonly Enemy enemy;

    public SpiralBlossomInstance(SpiralBlossomPattern pattern, Enemy enemy)
    {
        this.pattern = pattern;
        this.enemy = enemy;
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
            if (!enemy.gameObject.activeSelf)
                break;

            for (int i = 0; i < 12; i++)
            {
                float theta = angle + (i * 30f);
                Vector3 dir = Quaternion.Euler(0, 0, theta) * Vector3.up;
                BulletManager.Instance.FireBullet(firePoint.position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            }

            angle += pattern.SpiralSpeed * Time.deltaTime;
            yield return new WaitForSeconds(pattern.FireRate);
        }
    }
}

