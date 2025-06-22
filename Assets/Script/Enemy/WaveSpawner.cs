using System.Collections.Generic;
using UnityEngine;

//적의 소환을 담당하는 클래스
public class WaveSpawner : MonoBehaviour
{
    private static WaveSpawner insatnce = null;
    public static WaveSpawner Instance
    {
        get
        {
            insatnce = insatnce != null ? insatnce : FindFirstObjectByType<WaveSpawner>();
            return insatnce;
        }
    }

    //적의 소한에 대한 정보
    public EnemySpawnData[] wave;
    private Enemy[] pool;

    //현재 타이머
    [SerializeField]
    private float timer;
    //어디까지 소환했는가
    private int spawnIndex;

    private void Start()
    {
        pool = new Enemy[wave.Length];
        for(int i = 0; i < wave.Length; i++)
        {
            pool[i] = CreateEnemy(wave[i].enemyPrefab, wave[i].moveTypes);
        }
    }

    public void Flow()
    {
        if (wave == null || spawnIndex >= wave.Length)
            return;

        timer += Time.deltaTime;

        //타이머에 해당하는 적을 전부 생성
        while (spawnIndex < wave.Length && timer >= wave[spawnIndex].spawnTime)
        {
            pool[spawnIndex].transform.position = wave[spawnIndex].moveTypes[0].Point[0].position;
            pool[spawnIndex].gameObject.SetActive(true);
            if (pool[spawnIndex].TryGetComponent(out Boss boss))
                BossHPUI.Instance.SetBoss(boss);
            spawnIndex++;
        }
    }

    //적을 생성하는 메소드
    public Enemy CreateEnemy(Enemy prefab, List<MoveType> moveTypes)
    {
        //위치는 moveType의 첫 위기에서 시작하기 때문에 첫 moveType이 waitmovetype이라면 에러가 남 (wait 는 첫위치가 존재하지 않음)
        Enemy enemy = Instantiate(prefab, moveTypes[0].Point[0].position, Quaternion.identity, transform);
        //적이 어떻게 움직어야 하는지 넣기
        if (enemy.TryGetComponent(out MoveObject move))
        {
            move.moveTypes = moveTypes.ToArray();
        }
        enemy.gameObject.SetActive(false);
        return enemy;
    }

    public void Reset()
    {
        timer = 0;
        spawnIndex = 0;
    }
}
