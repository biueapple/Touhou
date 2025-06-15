using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/RandomShot")]
public class RandomShotBulletPattern : BulletPattern
{
    [SerializeField]
    [Header("한번에 발사될 총알의 개수")]
    private int bulletCount = 10;
    public int BulletCount => bulletCount;

    [SerializeField]
    [Header("최대 최소의 각도 범위")]
    private float spreadAngle = 60f;
    public float SpreadAngle => spreadAngle;
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new RandomPatternInstance(this, enemy);
    }
}

public class RandomPatternInstance : PatternInstance
{
    private readonly RandomShotBulletPattern pattern;

    public RandomPatternInstance(RandomShotBulletPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //아래 방향으로 랜덤 범위 발사
    public override void Fire(Transform firePoint)
    {
        for (int i = 0; i < pattern.BulletCount; i++)
        {
            float angle = Random.Range(-pattern.SpreadAngle / 2f, pattern.SpreadAngle / 2f);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.down;
            BulletManager.Instance.FireBullet(firePoint.position, direction, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
        }
    }
}