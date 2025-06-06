using System.Collections.Generic;
using UnityEngine;

//현재 사용중이지 않는 클래스
[CreateAssetMenu(menuName = "Waves/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public List<EnemySpawnData> enemies;
}
