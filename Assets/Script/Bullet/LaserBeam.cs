using UnityEngine;

public class LaserBeam : Bullet
{
    //경고용 스프라이트
    public SpriteRenderer waring;
    //진짜 레이저
    public SpriteRenderer laser;
    //충돌처리 collider
    private BoxCollider boxCollider;
    public float start = 1;
    public float end = 2;
    
    public override void Initialize(Vector3 dir, float damage, AnimationCurve speed)
    {
        base.Initialize(dir, damage, speed);
        boxCollider = GetComponent<BoxCollider>();
        //왜 dir의 반대가 up이여야 하는지 모르겠네
        transform.up = -dir;
    }


    private void OnTriggerEnter(Collider other)
    {
        //적과의 충돌시 체력을 깍기
        if (other.TryGetComponent(out Enemy enemy))
        {
            enemy.HP -= damage;
        }
        //플레이어의 기체와 충돌시 목숨을 하나 깍기
        else if (other.TryGetComponent(out Player_Ship ship))
        {
            ship.Hit();
        }
    }

    public override void Tick()
    {
        if (!isActive) return;
        //발사하고 1초 지나야 진짜
        timeAlive += Time.deltaTime;
        if (timeAlive >= start)
        {
            boxCollider.enabled = true;
            waring.enabled = false;
            laser.enabled = true;
        }
        //발사하고 2초가 지나면 사라지게
        if(timeAlive > end)
        {
            ReturnToPool();
        }
    }

    //다시 풀로 돌아가기
    public override void ReturnToPool()
    {
        base.ReturnToPool();
        boxCollider.enabled = false;
        waring.enabled = true;
        laser.enabled = false;
    }
}
