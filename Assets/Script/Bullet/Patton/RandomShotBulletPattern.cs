using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/RandomShot")]
public class RandomShotBulletPattern : BulletPattern
{
    public int bulletCount = 10;
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