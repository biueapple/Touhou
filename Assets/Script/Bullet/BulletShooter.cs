using UnityEngine;

//적이 총알을 발사할 때 사용하는 클래스
public class BulletShooter : MonoBehaviour
{
    ////어떤 패턴으로 발사할지
    //public BulletPattern[] pattern;
    ////실제 패턴 기능을 하는 클래스
    //private PatternInstance[] patternInstance;
    //public PatternInstance[] PatternInstance { get { return patternInstance; }  set { patternInstance = value; } }
    ////발사의 딜레이
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

    //STGManager가 관리함
    public void Tick()
    {
        if (patternDatas == null)
            return;

        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].timer += Time.deltaTime;
            if (patternDatas[i].timer >= patternDatas[i].fireDelay)
            {
                patternDatas[i].patternInstance.Fire(transform); // 현재 위치에서 발사
                patternDatas[i].timer = 0f;
            }
        }
    }
}
