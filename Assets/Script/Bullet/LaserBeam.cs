using UnityEngine;

public class LaserBeam : Bullet
{
    //���� ��������Ʈ
    public SpriteRenderer waring;
    //��¥ ������
    public SpriteRenderer laser;
    //�浹ó�� collider
    private BoxCollider boxCollider;
    public float start = 1;
    public float end = 2;
    
    public override void Initialize(Vector3 dir, float damage, AnimationCurve speed)
    {
        base.Initialize(dir, damage, speed);
        boxCollider = GetComponent<BoxCollider>();
        //�� dir�� �ݴ밡 up�̿��� �ϴ��� �𸣰ڳ�
        transform.up = -dir;
    }


    private void OnTriggerEnter(Collider other)
    {
        //������ �浹�� ü���� ���
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.HP -= damage;
        }
        //�÷��̾��� ��ü�� �浹�� ����� �ϳ� ���
        else if (other.TryGetComponent(out Player_Ship ship))
        {
            ship.Hit();
        }
    }

    public override void Tick()
    {
        if (!isActive) return;
        //�߻��ϰ� 1�� ������ ��¥
        timeAlive += Time.deltaTime;
        if (timeAlive >= start)
        {
            boxCollider.enabled = true;
            waring.enabled = false;
            laser.enabled = true;
        }
        //�߻��ϰ� 2�ʰ� ������ �������
        if(timeAlive > end)
        {
            ReturnToPool();
        }
    }

    //�ٽ� Ǯ�� ���ư���
    public override void ReturnToPool()
    {
        base.ReturnToPool();
        boxCollider.enabled = false;
        waring.enabled = true;
        laser.enabled = false;
    }
}
