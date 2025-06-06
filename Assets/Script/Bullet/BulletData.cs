using UnityEngine;

[CreateAssetMenu(fileName = "bulletData", menuName = "Bullet")]
public class BulletData : ScriptableObject
{
    //총알의 프리팹
    public Bullet bulletPrefab;
    //총알의 고유 값 (objectPolling 에서 생성할때 필요함)
    public int bulletId;
}
