using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/ZigzagBeamPattern")]
public class ZigzagBeamPattern : BulletPattern
{
    
    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new ZigzagtBeamInstance(this, enemy);
    }
}

//실제 작동하는 클래스
public class ZigzagtBeamInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly ZigzagBeamPattern pattern;

    public ZigzagtBeamInstance(ZigzagBeamPattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
            //초기 위치     y는 0까지 커자고 x는 -10 까지 줄고 
        for (Vector3 position = new (0, InfoStatic.ScreenBot * 2, 0); position.y < 0; position.y += 1f, position.x -= 1f)
        {
            //좌우에서 위 45도 각도로 발사
            Vector3 dir = Quaternion.Euler(0, 0, -45) * Vector3.up;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2.5f;
        }

        //초기 위치     y는 0까지 커자고 x는 10 까지 커지고 
        for (Vector3 position = new (0, InfoStatic.ScreenBot * 2, 0); position.y < 0; position.y += 1, position.x += 1)
        {
            //좌우에서 위 45도 각도로 발사
            Vector3 dir = Quaternion.Euler(0, 0, 45) * Vector3.up;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2.5f;
        }
    }
}
