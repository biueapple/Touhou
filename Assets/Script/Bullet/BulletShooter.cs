using UnityEngine;

public class BulletShooter : MonoBehaviour
{
    public BulletData data;
    public BulletPattern pattern;
    private PatternInstance patternInstance;
    public float fireDelay = 1f;
    private float timer;

    private void Start()
    {
        ObjectPooling.Instance.Registration(data.bulletId, data.bulletPrefab, 50);
        patternInstance = pattern.CreateInstance();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireDelay)
        {
            patternInstance.Fire(transform, data.bulletId); // 현재 위치에서 발사
            timer = 0f;
        }
    }
}
