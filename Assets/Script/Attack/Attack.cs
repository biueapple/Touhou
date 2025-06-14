using UnityEngine;

//플레이어의 기체가 사용하는 공격 스크립트
public class Attack : MonoBehaviour
{
    //총알에 대한 정보 스크립터블 오브젝트로 만들어져 있음
    [SerializeField]
    protected BulletData data;
    [SerializeField]
    protected AnimationCurve speed;


    //플레이어가 획득한 파워가 적용되는 공간 maxDamage까지 오르면 다음 무기의 currentDamage가 올라감
    //현재 대미지 (파워)
    [SerializeField]
    protected float currentDamage = 0;
    public float CurrentDamage { get { return currentDamage; } set { currentDamage = Mathf.Min(value, maxDamage); } }
    //대미지에 곱해지는 값 (파워 1당 몇의 대미지인지)
    [SerializeField]
    protected float magnifying = 1;
    public float Magnifying { get { return magnifying; } }
    //대미지에 기본적으로 더해지는 값
    [SerializeField]
    protected float additional = 1;
    public float Additional { get => additional; }
    //최대 대미지
    [SerializeField]
    protected float maxDamage = 1;
    public float MaxDamage { get { return maxDamage; } }
    //공격의 딜레이
    [SerializeField]
    protected float delay = 0.1f;
    //딜레이 시간을 재는 타이머
    protected float timer;

    void Awake()
    {
        //타이머와
        timer = Time.time;
        //현재 대미지 초기화
        currentDamage = 0; 
        //이 공격이 사용할 총알을 오브젝트 풀링에 등록하여 생산
        ObjectPooling.Instance.Registration(data.bulletId, data.bulletPrefab);
    }

    //발사
    public void Fire()
    {
        //대미지가 0이거나 딜레이 시간 조건 미달성
        if (currentDamage <= 0 || timer + delay > Time.time)
            return;

        //좌우에서 하나씩 발사
        CreateBullet(transform.position + new Vector3(-0.1f, 0, 0), currentDamage * magnifying + additional, Vector3.up, speed);
        CreateBullet(transform.position + new Vector3(0.1f, 0, 0), currentDamage * magnifying + additional, Vector3.up, speed);

        //타이머 재설정
        timer = Time.time;
    }

    //총알을 생성하고 발사
    private void CreateBullet(Vector3 position, float damage, Vector3 dir, AnimationCurve speed)
    {
        //총알을 생성하고 발사하고 움직임까지 제어해줌
        BulletManager.Instance.FireBullet(position, dir, damage, speed, data.bulletId);
    }

    //파워를 먹으면 이 메소드를 호출해 적용시킴
    public float AddDamage(float amount)
    {
        float space = maxDamage - currentDamage;
        float used = Mathf.Min(space, amount);
        currentDamage += used;
        return used;
    }
}
