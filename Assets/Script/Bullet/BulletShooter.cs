using UnityEngine;

//���� �Ѿ��� �߻��� �� ����ϴ� Ŭ����
public class BulletShooter : MonoBehaviour
{
    ////� �������� �߻�����
    //public BulletPattern[] pattern;
    ////���� ���� ����� �ϴ� Ŭ����
    //private PatternInstance[] patternInstance;
    //public PatternInstance[] PatternInstance { get { return patternInstance; }  set { patternInstance = value; } }
    ////�߻��� ������
    //public float fireDelay = 1f;

    public PatternData[] patternDatas = null;

    private void Start()
    {
        if (patternDatas == null)
            return;

        for(int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance();
        }

        //for(int i = 0; i < pattern.BulletDatas.Length; i++)
        //{
        //    ObjectPooling.Instance.Registration(pattern.BulletDatas[i].bulletId, pattern.BulletDatas[i].bulletPrefab, 100);
        //}        
        //patternInstance = pattern.CreateInstance();
    }

    //STGManager�� ������
    public void Tick()
    {
        if (patternDatas == null)
            return;

        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].timer += Time.deltaTime;
            if (patternDatas[i].timer >= patternDatas[i].fireDelay)
            {
                patternDatas[i].patternInstance.Fire(transform); // ���� ��ġ���� �߻�
                patternDatas[i].timer = 0f;
            }
        }
    }
}
