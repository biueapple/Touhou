using UnityEngine;

public class Bullet : MonoBehaviour
{
    //�Ѿ��� ������ (��ũ��Ʈ ������Ʈ�� �������� set���� ���� �־���)
    private int hash;
    public int Hash { get { return hash; } set { hash = value; } }

    //�Ѿ��� ����� (�����ɶ� �־���)
    protected float damage = 1;
    public float Damage { get { return damage; } set { damage = value; } }

    //�Ѿ��� ������ �ϴ� ����
    protected Vector3 direction = Vector3.up;
    public Vector3 Direction { get { return direction; } set { direction = value; } }

    //�Ѿ��� �ӵ�
    protected AnimationCurve speed;
    public AnimationCurve Speed { get { return speed; } set { speed = value; } }
    protected float timeAlive;

    //�Ѿ��� ���� Ȱ��ȭ �������� ���谰�� ���� (�浹, ������ ����� false��)
    protected bool isActive = true;

    //�浹
    private void OnTriggerEnter(Collider other)
    {
        //������ �浹�� ü���� ���
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.HP -= damage;
            ScoreManager.Instance.Add(InfoStatic.hit);
            ReturnToPool();
        }
        //�÷��̾��� ��ü�� �浹�� ����� �ϳ� ���
        else if(other.TryGetComponent(out Player_Ship ship))
        {
            ship.Hit();
            ReturnToPool();
        }
    }

    //�ʱ�ȭ
    public virtual void Initialize(Vector3 dir, float damage, AnimationCurve speed)
    {
        this.damage = damage;
        this.speed = speed;
        direction = dir.normalized;
        isActive = true;
        timeAlive = 0;
    }

    //bulletManager���� ȣ�����ִ� ������ ����
    public virtual void Tick()
    {
        if (!isActive) return;
        transform.position += speed.Evaluate(timeAlive) * Time.deltaTime * direction;
        timeAlive += Time.deltaTime;
    }

    //�Ѿ� ��Ȱ��ȭ
    public virtual void ReturnToPool()
    {
        isActive = false;
        BulletManager.Instance.UnregisterBullet(this);
    }
}
