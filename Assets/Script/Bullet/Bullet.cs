using UnityEngine;

public class Bullet : MonoBehaviour
{
    private float damage = 1;
    public float Damage { get { return damage; } set { damage = value; } }

    private Vector3 velocity = Vector3.up;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }

    private float speed;
    public float Speed { get { return speed; } set { speed = value; } }

    void Update()
    {
        transform.position += Time.deltaTime * speed * velocity;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.HP -= damage;
            ObjectPooling.Instance.DestroyBullet(this);
        }
    }
}
