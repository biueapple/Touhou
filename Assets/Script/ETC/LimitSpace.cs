using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LimitSpace : MonoBehaviour
{
    //아이템과 총알의 범위를 제한하는 콜라이더 (벗어나면 비활성화)
    [SerializeField]
    private BoxCollider box;
    //유닛이 나가지 못하도록 제한하는 콜라이더 (플레이어 기체는 나가지 못하도록 적은 나가면 비활성화 되도록)
    [SerializeField]
    private BoxCollider unitLimit;
    //플레이어 기체
    private Player_Ship ship;

    private void Update()
    {
        //플레이어를 제한할 콜라이더가 없다면
        if (unitLimit == null)
            return;

        //플레이어가 없다면
        if(ship == null)
        {
            ship = Player.Instance.Ship;
            //한프레임 정도는 다음으로 넘겨도 문제가 없음 (혹시 플레이어 기체가 null일수도 있으니)
            return;
        }    

        //위치를 제한
        ship.transform.position = new Vector3(Mathf.Clamp(ship.transform.position.x, unitLimit.center.x - unitLimit.size.x * 0.5f, unitLimit.center.x + unitLimit.size.x * 0.5f),
                                                   Mathf.Clamp(ship.transform.position.y, unitLimit.center.y - unitLimit.size.y * 0.5f, unitLimit.center.y + unitLimit.size.y * 0.5f));
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //적이 범위 안으로 들어옴 (unitLimit하고만 충돌하도록 설정상태임)
        if (other.TryGetComponent(out Enemy enemy))
        {
            //적을 활성화 (패턴을 발사 가능한 상태)
            STGManager.Instance.Enemies.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //총알이 범위 바깥으로 나감 (box collider)
        if (other.TryGetComponent(out Bullet bullet))
        {
            //총알 비활성화
            bullet.ReturnToPool();
        }
        //아이템이 범위 바깥으로 나감 (box collider)
        else if (other.TryGetComponent(out Item item))
        {
            //아이템 비활성화
            item.gameObject.SetActive(false);
        }
        //적이 범위 바깥으로 나감 (unitLimit collider)
        else if(other.TryGetComponent(out Enemy enemy))
        {
            //적을 비활성화
            STGManager.Instance.Enemies.Remove(enemy);
            enemy.gameObject.SetActive(false);
        }
    }
}
