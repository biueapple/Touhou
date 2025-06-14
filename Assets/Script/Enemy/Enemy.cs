using UnityEngine;
using UnityEngine.Rendering;

public class Enemy : MonoBehaviour
{
    //ü��
    [SerializeField]
    protected Item item;
    public float probability;
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
    protected BulletShooter bulletShooter;
    public BulletShooter BulletShooter { get { return bulletShooter; } }
    protected MoveObject moveObject;
    public MoveObject MoveObject { get { return moveObject; } set { moveObject = value; } }


    protected void Start()
    {
        bulletShooter = GetComponent<BulletShooter>();
        moveObject = GetComponent<MoveObject>();
    }

    public void Dead()
    {
        if(Random.Range(0f, 1f) > probability)
            ItemManager.Instance.CreateItem(item.Type.ToString(), transform.position);
        STGManager.Instance.Enemies.Remove(this);
        gameObject.SetActive(false);
    }
}
