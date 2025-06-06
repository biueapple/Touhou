using System.Collections.Generic;
using UnityEngine;

public class STGManager : MonoBehaviour
{
    //싱글톤
    private static STGManager insatnce = null;
    public static STGManager Instance 
    {
        get
        {
            insatnce = insatnce != null ? insatnce : FindFirstObjectByType<STGManager>();
            insatnce = insatnce != null ? insatnce : new GameObject("STGManager").AddComponent<STGManager>();
            return insatnce;
        }
    }

    //등작한 적들 (limit 범위 안으로 들어온 적들만)
    [SerializeField]
    private List<Enemy> enemies = new();
    public List<Enemy> Enemies { get { return enemies; } }

    //가장 가까운 적을 리턴해주는 메소드
    public Enemy NearEnemy(Vector3 position)
    {
        Enemy near = null;
        float distance = float.MaxValue;
        foreach(Enemy enemy in enemies)
        {
            float newDistance = Vector3.Distance(position, enemy.transform.position);
            if (newDistance < distance)
            {
                near = enemy;
                distance = newDistance;
            }
        }
        return near;
    }

    private void Awake()
    {
        //리플레이에서 같은 플레이를 보장하기 위해
        Random.InitState(0);
        //프레임 고정
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        //올바른 범위 안에 들어온 적만 공격을 하도록 (화면 밖으로 나간 적이 공격을 해선 안됌)
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].BulletShooter.Tick();
        }
    }
}
