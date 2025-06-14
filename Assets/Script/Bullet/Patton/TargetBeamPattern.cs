using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/TargetBeamPattern")]
public class TargetBeamPattern : BulletPattern
{
    [Header("발사할 레이저 갯수")]
    public int count;
    [Header("레이저 사이의 텀")]
    public float term;
    //패턴을 생산
    public override PatternInstance CreateInstance()
    {
        return new TargetBeamInstance(this);
    }
}

//실제 작동하는 클래스
public class TargetBeamInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly TargetBeamPattern pattern;

    public TargetBeamInstance(TargetBeamPattern pattern)
    {
        this.pattern = pattern;
    }

    public override void Fire(Transform firePoint)
    {
        Player.Instance.StartCoroutine(FireSequence(firePoint));
    }

    private IEnumerator FireSequence(Transform firePoint)
    {
        for(int i = 0; i < pattern.count; i++)
        {
            Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(firePoint.position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2;

            yield return new WaitForSeconds(pattern.term);
        }
    }
}
