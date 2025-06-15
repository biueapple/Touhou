using System.Collections;
using UnityEngine;

[CreateAssetMenu(menuName = "BulletPattern/TargetBeamPattern")]
public class TargetBeamPattern : BulletPattern
{
    [SerializeField]
    [Header("발사할 레이저 갯수")]
    private int count;
    public int Count => count;

    [SerializeField]
    [Header("레이저 사이의 텀")]
    private float term;
    public float Term => term;

    //패턴을 생산
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new TargetBeamInstance(this, enemy);
    }
}

//실제 작동하는 클래스
public class TargetBeamInstance : PatternInstance
{
    //자신을 생성한 오브젝트 (오브젝트 정보를 기반으로 작동하기에)
    private readonly TargetBeamPattern pattern;
    private readonly Enemy enemy;

    public TargetBeamInstance(TargetBeamPattern pattern, Enemy enemy)
    {
        this.pattern = pattern;
        this.enemy = enemy;
    }

    public override void Fire(Transform firePoint)
    {
        Player.Instance.StartCoroutine(FireSequence(firePoint));
    }

    private IEnumerator FireSequence(Transform firePoint)
    {
        for(int i = 0; i < pattern.Count; i++)
        {
            if (!enemy.gameObject.activeSelf)
                break;

            Vector3 dir = (Player.Instance.Ship.transform.position - firePoint.position).normalized;
            LaserBeam laser = (LaserBeam)BulletManager.Instance.FireBullet(firePoint.position, dir.normalized, 2, pattern.Speed, pattern.BulletDatas[0].bulletId);
            laser.start = 1;
            laser.end = 2;

            yield return new WaitForSeconds(pattern.Term);
        }
    }
}
