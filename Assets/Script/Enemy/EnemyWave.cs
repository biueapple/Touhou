using System.Collections.Generic;
using UnityEngine;

//���� ��������� �ʴ� Ŭ����
[CreateAssetMenu(menuName = "Waves/EnemyWave")]
public class EnemyWave : ScriptableObject
{
    public List<EnemySpawnData> enemies;
}
