using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : Bullet
{
    //어떤 탄을 발사할건지
    public BulletData bulletData;
    //분할될 탄의 속도
    public AnimationCurve splitSpeed;

    //각도마다 하나씩
    public List<float> splitAngle = new();
    //Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
    
    //몇초후에 분할될 것인지
    public float timer;
    private float time;

    //분할 후에 사라질것인지
    public bool deactive;

    public override void Initialize(Vector3 dir, float damage, AnimationCurve speed)
    {
        base.Initialize(dir, damage, speed);
        time = Time.time;
    }

    private void Update()
    {
        if(time + timer <= Time.time)
        {
            //분할
            Split();
            if (deactive)
                ReturnToPool();
            time = Time.time;
        }
    }

    private void Split()
    {
        for(int i = 0; i < splitAngle.Count; i++)
        {
            BulletManager.Instance.FireBullet(transform.position, Quaternion.Euler(0, 0, splitAngle[i]) * Vector3.up, 2, splitSpeed, bulletData.bulletId);
        }
    }
}
