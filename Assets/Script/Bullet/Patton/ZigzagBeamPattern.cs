using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/ZigzagBeamPattern")]
public class ZigzagBeamPattern : BulletPattern
{
    
    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new ZigzagtBeamInstance(this, enemy);
    }
}

//���� �۵��ϴ� Ŭ����
public class ZigzagtBeamInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly ZigzagBeamPattern pattern;

    public ZigzagtBeamInstance(ZigzagBeamPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
            //�ʱ� ��ġ     y�� 0���� Ŀ�ڰ� x�� -10 ���� �ٰ� 
        for (Vector3 position = new (0, InfoStatic.ScreenBot * 2, 0); position.y < 0; position.y += 1f, position.x -= 1f)
        {
            //�¿쿡�� �� 45�� ������ �߻�
            Vector3 dir = Quaternion.Euler(0, 0, -45) * Vector3.up;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2.5f;
        }

        //�ʱ� ��ġ     y�� 0���� Ŀ�ڰ� x�� 10 ���� Ŀ���� 
        for (Vector3 position = new (0, InfoStatic.ScreenBot * 2, 0); position.y < 0; position.y += 1, position.x += 1)
        {
            //�¿쿡�� �� 45�� ������ �߻�
            Vector3 dir = Quaternion.Euler(0, 0, 45) * Vector3.up;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2.5f;
        }
    }
}
