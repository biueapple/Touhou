using UnityEngine;

//적이 총알을 발사할 때 사용하는 클래스 (보스는 사용하지 않음 패턴이 여러개가 되면 오히려 불편해서)
public class BulletShooter : MonoBehaviour
{
    public PatternData[] patternDatas = null;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        if (patternDatas == null)
            return;

        for(int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance(enemy);
        }
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
