using UnityEngine;

public class Bullet : MonoBehaviour
{
    private int hash;
    public int Hash { get { return hash; } set { hash = value; } }

    private float damage = 1;
    public float Damage { get { return damage; } set { damage = value; } }

    private Vector3 direction = Vector3.up;
    public Vector3 Direction { get { return direction; } set { direction = value; } }

    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    protected bool isActive = true;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.HP -= damage;
            ReturnToPool();
        }
        else if(other.TryGetComponent(out Player_Ship ship))
        {
            ship.Hit();
            ReturnToPool();
        }
    }

    public virtual void Initialize(Vector3 dir, float damage, float speed)
    {
        this.damage = damage;
        this.speed = speed;
        direction = dir.normalized;
        isActive = true;
    }

    public virtual void Tick()
    {
        if (!isActive) return;
        transform.position += direction * speed * Time.deltaTime;
    }

    public void ReturnToPool()
    {
        isActive = false;
        BulletManager.Instance.UnregisterBullet(this);
    }
}
