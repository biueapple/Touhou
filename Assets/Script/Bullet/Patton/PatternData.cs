using UnityEngine;

[System.Serializable]
public class PatternData
{
    //� �������� �߻�����
    public BulletPattern pattern;
    //���� ���� ����� �ϴ� Ŭ����
    public PatternInstance patternInstance;
    //�߻��� ������
    public float fireDelay = 1f;
    //�����̸� ����ϴ� Ÿ�̸�
    public float timer;

    public void CreateInstance()
    {
        for (int i = 0; i < pattern.BulletDatas.Length; i++)
        {
            ObjectPooling.Instance.Registration(pattern.BulletDatas[i].bulletId, pattern.BulletDatas[i].bulletPrefab);
        }
        patternInstance = pattern.CreateInstance();
    }
}
