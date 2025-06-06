using UnityEngine;

public class Enemy : MonoBehaviour
{
    //체력
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

    //발사를 당담하는 클래스 (STGManager에서 get으로 사용중)
    [SerializeField]
    private BulletShooter bulletShooter;
    public BulletShooter BulletShooter { get { return bulletShooter; } }
    
}
