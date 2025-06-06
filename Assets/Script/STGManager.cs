using System.Collections.Generic;
using UnityEngine;

public class STGManager : MonoBehaviour
{
    //�̱���
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

    //������ ���� (limit ���� ������ ���� ���鸸)
    [SerializeField]
    private List<Enemy> enemies = new();
    public List<Enemy> Enemies { get { return enemies; } }

    //���� ����� ���� �������ִ� �޼ҵ�
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
        //���÷��̿��� ���� �÷��̸� �����ϱ� ����
        Random.InitState(0);
        //������ ����
        Application.targetFrameRate = 60;
    }

    private void Update()
    {
        //�ùٸ� ���� �ȿ� ���� ���� ������ �ϵ��� (ȭ�� ������ ���� ���� ������ �ؼ� �ȉ�)
        for (int i = 0; i < enemies.Count; i++)
        {
            enemies[i].BulletShooter.Tick();
        }
    }
}
