using System.Collections.Generic;
using UnityEngine;

public class BulletManager : MonoBehaviour
{
    //�̱���
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

    //���� Ȱ��ȭ ������ �Ѿ˵�
    private List<Bullet> activeBullets = new();

    private void Awake()
    {
        instance = this;
    }

    //�Ѿ˵��� ������ ����
    private void Update()
    {
        for (int i = 0; i < activeBullets.Count; i++)
        {
            activeBullets[i].Tick();
        }
    }

    //�Ѿ� �������� ��� (�ۿ��� ����� ������ ����� ��� private)
    private void RegisterBullet(Bullet bullet)
    {
        if (!activeBullets.Contains(bullet))
            activeBullets.Add(bullet);
    }

    //�Ѿ��� ��Ȱ��ȭ �ϴ� �޼ҵ� (bullet ��ũ��Ʈ �̿ܿ� ȣ���� ������ ����)
    public void UnregisterBullet(Bullet bullet)
    {
        activeBullets.Remove(bullet);
        ObjectPooling.Instance.DestroyBullet(bullet);
    }

    //�Ѿ��� �߻��ϴ� �޼ҵ� 
    public void FireBullet(Vector3 position, Vector3 direction, float damage, float speed, int hash)
    {
        var bullet = ObjectPooling.Instance.CreateBullet(hash); // Ǯ���� ������
        bullet.transform.position = position;
        bullet.Initialize(direction, damage, speed);
        bullet.gameObject.SetActive(true);
        bullet.transform.up = direction;
        RegisterBullet(bullet);
    }
}
