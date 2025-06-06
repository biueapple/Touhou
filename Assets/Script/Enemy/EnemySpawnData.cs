using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class EnemySpawnData
{
    [Header("언제 소환될건지")]
    public float spawnTime;
    [Header("프리팹")]
    public Enemy enemyPrefab;
    [Header("어디서 어디로 갈건지")]
    [Tooltip("적이 이동할 MoveType들을 순서대로 지정하세요")]
    public List<MoveType> moveTypes;
}
