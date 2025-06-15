using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpiralBlossomPattern")]
public class SpiralBlossomPattern : BulletPattern
{
    [SerializeField]
    [Header("1초에 증가할 각도")]
    private float spiralSpeed = 60f;
    public float SpiralSpeed => spiralSpeed;

    [SerializeField]
    [Header("다음 탄이 발사되는 딜레이")]
    private float fireRate = 0.1f;
    public float FireRate => fireRate;

    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new SpiralBlossomInstance(this, enemy);
    }
}


//실제 작동하는 클래스
public class SpiralBlossomInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
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

    //현재 각도
    private float angle = 0f;
    private IEnumerator FireSequence(Transform firePoint)
    {
        for (int wave = 0; wave < 30; wave++) // 한 패턴 동안 30회 발사
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

