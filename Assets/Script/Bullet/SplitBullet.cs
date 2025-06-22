using System.Collections.Generic;
using UnityEngine;

public class SplitBullet : Bullet
{
    //� ź�� �߻��Ұ���
    public BulletData bulletData;
    //���ҵ� ź�� �ӵ�
    public AnimationCurve splitSpeed;

    //�������� �ϳ���
    public List<float> splitAngle = new();
    //Vector3 dir = Quaternion.Euler(0, 0, angle) * Vector3.up;
    
    //�����Ŀ� ���ҵ� ������
    public float timer;
    private float time;

    //���� �Ŀ� �����������
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
            //����
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
