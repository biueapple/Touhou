using UnityEngine;

//실제 작동할 패턴을 생성해주는 클래스
[CreateAssetMenu(menuName = "BulletPattern/RandomShot")]
public class RandomShotBulletPattern : BulletPattern
{
    //한번에 발사될 총알의 개수
    public int bulletCount = 10;
    //최대 최소의 각도 범위
    public float spreadAngle = 60f;

    public override PatternInstance CreateInstance()
    {
        return new RandomPatternInstance(this);
    }
}

public class RandomPatternInstance : PatternInstance
{
    private RandomShotBulletPattern pattern;

    public RandomPatternInstance(RandomShotBulletPattern pattern)
    {
        this.pattern = pattern;
    }

    //아래 방향으로 랜덤 범위 발사
    public override void Fire(Transform firePoint, int hash)
    {
        for (int i = 0; i < pattern.bulletCount; i++)
        {
            float angle = Random.Range(-pattern .spreadAngle / 2f, pattern.spreadAngle / 2f);
            Vector3 direction = Quaternion.Euler(0, 0, angle) * Vector3.down;
            BulletManager.Instance.FireBullet(firePoint.position, direction, 2, 2, hash);
        }
    }
}