using UnityEngine;

//homing이랑 탄만 다르네
//[CreateAssetMenu(menuName = "BulletPattern/DelayedClone")]
public class DelayedClonePattern : BulletPattern
{
    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new DelayedCloneInstance(this, enemy);
    }
}

//실제 작동하는 클래스
public class DelayedCloneInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly DelayedClonePattern pattern;

    public DelayedCloneInstance(DelayedClonePattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //패턴 발사 플레이어에게 발사
    public override void Fire(Transform firePoint)
    {
        
    }
}