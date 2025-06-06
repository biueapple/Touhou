using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    [Header("���� ��ȯ�ɰ���")]
    public float spawnTime;
    [Header("������")]
    public Enemy enemyPrefab;
    [Header("��� ���� ������")]
    [Tooltip("���� �̵��� MoveType���� ������� �����ϼ���")]
    public List<MoveType> moveTypes;
}
