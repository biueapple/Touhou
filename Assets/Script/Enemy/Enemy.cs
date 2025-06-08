using UnityEngine;

public class Enemy : MonoBehaviour
{
    //ü��
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

    //�߻縦 ����ϴ� Ŭ���� (STGManager���� get���� �����)
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
