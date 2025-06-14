using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpiralBlossomPattern")]
public class SpiralBlossomPattern : BulletPattern
{
    [Header("1초에 증가할 각도")]
    public float spiralSpeed = 60f;
    [Header("다음 탄이 발사되는 딜레이")]
    public float fireRate = 0.1f;
    //패턴을 생산
    public override PatternInstance CreateInstance()
    {
        return new SpiralBlossomInstance(this);
    }
}


//실제 작동하는 클래스
public class SpiralBlossomInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly SpiralBlossomPattern pattern;

    public SpiralBlossomInstance(SpiralBlossomPattern pattern)
    {
        this.pattern = pattern;
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

