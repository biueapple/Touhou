using UnityEngine;

public class Enemy : MonoBehaviour
{
    //ü��
    [SerializeField]
    private Item item;
    [SerializeField]
    private float hp = 1;
    public float HP 
    { 
        get { return hp; } 
        set 
        { 
            hp = value;
            if (hp > 0)
                return;
            Instantiate(item, transform.position, Quaternion.identity);
            STGManager.Instance.Enemies.Remove(this);
            gameObject.SetActive(false);
        }
    }

    //�߻縦 ����ϴ� Ŭ���� (STGManager���� get���� �����)
    [SerializeField]
    private BulletShooter bulletShooter;
    public BulletShooter BulletShooter { get { return bulletShooter; } }
    
}
