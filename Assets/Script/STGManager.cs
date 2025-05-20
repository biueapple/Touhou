using System.Collections.Generic;
using UnityEngine;

public class STGManager : MonoBehaviour
{
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

    [SerializeField]
    private List<Enemy> enemies = new();
    public List<Enemy> Enemies { get { return enemies; } }

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
        Random.InitState(0);
    }
}
