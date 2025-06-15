using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/Boss1")]
public class BossPattern_1 : BulletPattern
{
    [SerializeField]
    [Header("한 방향으로 발사할 총알의 갯수")]
    private int bulletCount = 5;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("한 프레임에 움직일 다음 각도")]
    private float angleStep = 10f;
    public float AngleStep => angleStep;

    [SerializeField]
    [Header("다음 탄과의 딜레이")]
    private float delay;
    public float Delay => delay;

    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new BossPatternInstance(this, enemy);
    }
}

public class BossPatternInstance : PatternInstance
{
    private readonly BossPattern_1 pattern;
    private readonly Enemy enemy;

    //현재 각도
    private float currentAngle = 0f;

    public BossPatternInstance(BossPattern_1 pattern, Enemy enemy)
    {
        this.pattern = pattern;
        this.enemy = enemy;
    }

    public override void Fire(Transform firePoint)
    {
        Player.Instance.StartCoroutine(FireSequence(firePoint));
        //Vector3 dir = Quaternion.Euler(0, 0, currentAngle * side) * Player.Instance.RelativeDirection(firePoint);
        //BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

        //bullet++;
        //currentAngle += pattern.AngleStep;
        //if (bullet >= pattern.BulletCount)
        //{
        //    side *= -1;
        //    currentAngle = 0f;
        //    bullet = 0;
        //}
    }

    private IEnumerator FireSequence(Transform firePoint)
    {
        currentAngle = 0f;
        Vector3 angle = Player.Instance.RelativeDirection(firePoint);
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 dir = Quaternion.Euler(0, 0, currentAngle) * angle;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

            currentAngle += pattern.AngleStep;
            yield return new WaitForSeconds(pattern.Delay);
        }

        for (int i = 0; i < pattern.BulletCount; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 dir = Quaternion.Euler(0, 0, -currentAngle) * angle;
            BulletManager.Instance.FireBullet(firePoint.position, dir, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);

            currentAngle += pattern.AngleStep;
            yield return new WaitForSeconds(pattern.Delay);
        }
    }
}