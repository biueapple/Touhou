using UnityEngine;

[System.Serializable]
public class PatternData
{
    //어떤 패턴으로 발사할지
    public BulletPattern pattern;
    //실제 패턴 기능을 하는 클래스
    public PatternInstance patternInstance;
    //발사의 딜레이
    public float fireDelay = 1f;
    //딜레이를 계산하는 타이머
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
