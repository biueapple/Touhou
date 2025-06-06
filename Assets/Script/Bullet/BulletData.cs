using UnityEngine;

[CreateAssetMenu(fileName = "bulletData", menuName = "Bullet")]
public class BulletData : ScriptableObject
{
    //�Ѿ��� ������
    public Bullet bulletPrefab;
    //�Ѿ��� ���� �� (objectPolling ���� �����Ҷ� �ʿ���)
    public int bulletId;
}
