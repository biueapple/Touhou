using UnityEngine;

public class Bullet : MonoBehaviour
{
    //총알의 고유값 (스크립트 오브젝트로 정해지고 set으로 값을 넣어줌)
    private int hash;
    public int Hash { get { return hash; } set { hash = value; } }

    //총알의 대미지 (생성될때 넣어줌)
    protected float damage = 1;
    public float Damage { get { return damage; } set { damage = value; } }

    //총알이 가고자 하는 방향
    protected Vector3 direction = Vector3.up;
    public Vector3 Direction { get { return direction; } set { direction = value; } }

    //총알의 속도
    protected AnimationCurve speed;
    public AnimationCurve Speed { get { return speed; } set { speed = value; } }
    protected float timeAlive;

    //총알이 지금 활성화 상태인지 보험같은 느낌 (충돌, 범위를 벗어나면 false로)
    protected bool isActive = true;

    //충돌
    private void OnTriggerEnter(Collider other)
    {
        //적과의 충돌시 체력을 깍기
        if(other.TryGetComponent(out Enemy enemy))
        {
            enemy.HP -= damage;
            ScoreManager.Instance.Add(InfoStatic.hit);
            ReturnToPool();
        }
        //플레이어의 기체와 충돌시 목숨을 하나 깍기
        else if(other.TryGetComponent(out Player_Ship ship))
        {
            ship.Hit();
            ReturnToPool();
        }
    }

    //초기화
    public virtual void Initialize(Vector3 dir, float damage, AnimationCurve speed)
    {
        this.damage = damage;
        this.speed = speed;
        direction = dir.normalized;
        isActive = true;
        timeAlive = 0;
    }

    //bulletManager에서 호출해주는 움직임 제어
    public virtual void Tick()
    {
        if (!isActive) return;
        transform.position += speed.Evaluate(timeAlive) * Time.deltaTime * direction;
        timeAlive += Time.deltaTime;
    }

    //총알 비활성화
    public virtual void ReturnToPool()
    {
        isActive = false;
        BulletManager.Instance.UnregisterBullet(this);
    }
}
