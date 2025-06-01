using UnityEngine;

[CreateAssetMenu(fileName = "bulletData", menuName = "Bullet")]
public class BulletData : ScriptableObject
{
    public Bullet bulletPrefab;
    public int bulletId;
}
