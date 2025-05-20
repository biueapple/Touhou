using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField]
    protected Bullet bullet;
    [SerializeField]
    protected float currentDamage = 0;
    public float CurrentDamage { get { return currentDamage; } set { currentDamage = Mathf.Min(value, maxDamage); } }
    [SerializeField]
    protected float magnifying = 1;
    public float Magnifying { get { return magnifying; } }
    [SerializeField]
    protected float maxDamage = 1;
    public float MaxDamage { get { return maxDamage; } }

    [SerializeField]
    protected float delay = 0.1f;
    protected float timer;

    void Start()
    {
        timer = Time.time;
        currentDamage = 0; 
        ObjectPooling.Instance.Registration<Attack>(GetHashCode(), bullet);
    }

    public void Fire()
    {
        if (currentDamage <= 0 || timer + delay > Time.time)
            return;

        CreateBullet(transform.position + new Vector3(-0.1f, 0, 0), currentDamage * magnifying, Vector3.up, 6);
        CreateBullet(transform.position + new Vector3(0.1f, 0, 0), currentDamage * magnifying, Vector3.up, 6);

        timer = Time.time;
    }

    private void CreateBullet(Vector3 position, float damage, Vector3 dir, float speed)
    {
        Bullet b = ObjectPooling.Instance.CreateBullet(GetHashCode());
        b.transform.position = position;
        b.Damage = damage;
        b.Velocity = dir;
        b.Speed = speed;
        //ObjectPooling.Instance.DestroyBullet(b, InfoStatic.DestroyTimer);
    }

    public float AddDamage(float amount)
    {
        float space = maxDamage - currentDamage;
        float used = Mathf.Min(space, amount);
        currentDamage += used;
        return used;
    }
}
