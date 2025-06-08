using System.Collections.Generic;
using UnityEngine;

//���� ��ȯ�� ����ϴ� Ŭ����
public class WaveSpawner : MonoBehaviour
{
    //���� ���ѿ� ���� ����
    public EnemySpawnData[] wave;
    //���� Ÿ�̸�
    private float timer;
    //������ ��ȯ�ߴ°�
    private int spawnIndex;

    public void Flow()
    {
        if (wave == null || spawnIndex >= wave.Length)
            return;

        timer += Time.deltaTime;

        //Ÿ�̸ӿ� �ش��ϴ� ���� ���� ����
        while (spawnIndex < wave.Length && timer >= wave[spawnIndex].spawnTime)
        {
            EnemySpawnData data = wave[spawnIndex];
            CreateEnemy(data.enemyPrefab, data.moveTypes);
            spawnIndex++;
        }
    }

    //���� �����ϴ� �޼ҵ�
    public Enemy CreateEnemy(Enemy prefab, List<MoveType> moveTypes)
    {
        //��ġ�� moveType�� ù ���⿡�� �����ϱ� ������ ù moveType�� waitmovetype�̶�� ������ �� (wait �� ù��ġ�� �������� ����)
        Enemy enemy = Instantiate(prefab, moveTypes[0].Point[0].position, Quaternion.identity);
        //���� ��� ������� �ϴ��� �ֱ�
        if (enemy.TryGetComponent(out MoveObject move))
        {
            move.moveTypes = moveTypes.ToArray();
        }
        return enemy;
    }
}
