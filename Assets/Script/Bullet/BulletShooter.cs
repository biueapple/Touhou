using UnityEngine;

//���� �Ѿ��� �߻��� �� ����ϴ� Ŭ����
public class BulletShooter : MonoBehaviour
{
    //� �������� �߻�����
    public BulletPattern pattern;
    //���� ���� ����� �ϴ� Ŭ����
    private PatternInstance patternInstance;
    public PatternInstance PatternInstance { get { return patternInstance; }  set { patternInstance = value; } }
    //�߻��� ������
    public float fireDelay = 1f;
    //�����̸� ����ϴ� Ÿ�̸�
    private float timer;

    private void Start()
    {
        for(int i = 0; i < pattern.BulletDatas.Length; i++)
        {
            ObjectPooling.Instance.Registration(pattern.BulletDatas[i].bulletId, pattern.BulletDatas[i].bulletPrefab, 100);
        }        
        patternInstance = pattern.CreateInstance();
    }

    //STGManager�� ������
    public void Tick()
    {
        if (patternInstance == null)
            return;
        timer += Time.deltaTime;
        if (timer >= fireDelay)
        {
            patternInstance.Fire(transform); // ���� ��ġ���� �߻�
            timer = 0f;
        }
    }
}
