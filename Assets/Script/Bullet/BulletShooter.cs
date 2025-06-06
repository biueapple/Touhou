using UnityEngine;

//���� �Ѿ��� �߻��� �� ����ϴ� Ŭ����
public class BulletShooter : MonoBehaviour
{
    //�Ѿ˿� ���� ����
    public BulletData data;
    //� �������� �߻�����
    public BulletPattern pattern;
    //���� ���� ����� �ϴ� Ŭ����
    private PatternInstance patternInstance;
    //�߻��� ������
    public float fireDelay = 1f;
    //�����̸� ����ϴ� Ÿ�̸�
    private float timer;

    private void Start()
    {
        ObjectPooling.Instance.Registration(data.bulletId, data.bulletPrefab, 100);
        patternInstance = pattern.CreateInstance();
    }

    //STGManager�� ������
    public void Tick()
    {
        timer += Time.deltaTime;
        if (timer >= fireDelay)
        {
            patternInstance.Fire(transform, data.bulletId); // ���� ��ġ���� �߻�
            timer = 0f;
        }
    }
}
