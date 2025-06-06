using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //싱글톤
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

    //현재 활성화 상태인 총알들
    private List<Bullet> activeBullets = new();

    private void Awake()
    {
        instance = this;
    }

    //총알들의 움직임 제어
    private void Update()
    {
        for (int i = 0; i < activeBullets.Count; i++)
        {
            activeBullets[i].Tick();
        }
    }

    //총알 생성힐때 등록 (밖에서 사용할 이유가 현재는 없어서 private)
    private void RegisterBullet(Bullet bullet)
    {
        if (!activeBullets.Contains(bullet))
            activeBullets.Add(bullet);
    }

    //총알을 비활성화 하는 메소드 (bullet 스크립트 이외에 호출할 이유는 없음)
    public void UnregisterBullet(Bullet bullet)
    {
        activeBullets.Remove(bullet);
        ObjectPooling.Instance.DestroyBullet(bullet);
    }

    //총알을 발사하는 메소드 
    public void FireBullet(Vector3 position, Vector3 direction, float damage, float speed, int hash)
    {
        var bullet = ObjectPooling.Instance.CreateBullet(hash); // 풀에서 가져옴
        bullet.transform.position = position;
        bullet.Initialize(direction, damage, speed);
        bullet.gameObject.SetActive(true);
        bullet.transform.up = direction;
        RegisterBullet(bullet);
    }
}
