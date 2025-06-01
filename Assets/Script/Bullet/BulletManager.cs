using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    private static BulletManager instance;
    public static BulletManager Instance
    {
        get
        {
            instance = instance != null ? instance : FindFirstObjectByType<BulletManager>();
            instance = instance != null ? instance : new GameObject("BulletManager").AddComponent<BulletManager>();
            return instance;
        }
    }

    private List<Bullet> activeBullets = new();

    private void Awake()
    {
        instance = this;
    }

    private void Update()
    {
        for (int i = 0; i < activeBullets.Count; i++)
        {
            activeBullets[i].Tick();
        }
    }

    public void RegisterBullet(Bullet bullet)
    {
        if (!activeBullets.Contains(bullet))
            activeBullets.Add(bullet);
    }

    public void UnregisterBullet(Bullet bullet)
    {
        activeBullets.Remove(bullet);
        ObjectPooling.Instance.DestroyBullet(bullet);
    }

    public void FireBullet(Vector3 position, Vector3 direction, float damage, float speed, int hash)
    {
        var bullet = ObjectPooling.Instance.CreateBullet(hash); // 풀에서 가져옴
        bullet.transform.position = position;
        bullet.Initialize(direction, damage, speed);
        bullet.gameObject.SetActive(true);
        RegisterBullet(bullet);
    }
}
