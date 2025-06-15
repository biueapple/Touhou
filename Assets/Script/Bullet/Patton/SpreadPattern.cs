using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/SpreadPattern")]
public class SpreadPattern : BulletPattern
{
    [SerializeField]
    [Header("한쪽으로 발사하는 탄의 갯수")]
    private int bulletCount = 4;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("탄 사이의 딜레이")]
    private float delay = 0.1f;
    public float Delay => delay;

    [SerializeField]
    [Header("탄 사이의 각도")]
    private float angle = 2;
    public float Angle => angle;

    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new SpreadPatternInstance(this, enemy);
    }
}

//실제 작동하는 클래스
public class SpreadPatternInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
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
        // 왼쪽으로 퍼지는 방향
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 spreadDir = Quaternion.Euler(0, 0, -pattern.Angle * i) * baseDir;
            BulletManager.Instance.FireBullet(firePoint.position, spreadDir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            yield return new WaitForSeconds(pattern.Delay);
        }

        // 오른쪽으로 퍼지는 방향
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

