using UnityEngine;

public class Enemy : MonoBehaviour
{
    //체력
    [SerializeField]
    protected Item item;
    [SerializeField]
    protected float hp = 1;
    public virtual float HP 
    { 
        get { return hp; } 
        set 
        { 
            hp = value;
            if (hp > 0)
                return;

            Dead();
        }
    }

    //발사를 당담하는 클래스 (STGManager에서 get으로 사용중)
    [SerializeField]
    protected BulletShooter bulletShooter;
    public BulletShooter BulletShooter { get { return bulletShooter; } }
    
    public void Dead()
    {
        ItemManager.Instance.CreateItem(item.Type.ToString(), transform.position);
        STGManager.Instance.Enemies.Remove(this);
        gameObject.SetActive(false);
    }
}
