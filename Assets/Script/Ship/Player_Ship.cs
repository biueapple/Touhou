using System.Collections;
using UnityEngine;

//사용자 기체
public class Player_Ship : MonoBehaviour
{
    //평범한 상태가 사용할 콜라이더
    [SerializeField]
    private Collider nomalCollider;
    public Collider NomalCollider { get => nomalCollider; }
    //쉬프트를 누른 상태가 사용할 콜라이더
    [SerializeField]
    private Collider shiftCollider;
    public Collider ShiftCollider { get => shiftCollider; }
    //쉬프트를 누르면 기체의 중간 부분에 빨간 점이 생겨야 해서 그 점 오브젝트
    [SerializeField]
    private GameObject center;
    //에니메이션
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return animator; } }

    //플레이어 기체의 움직임을 적용시키는 클래스
    [SerializeField]
    private ShipMove move;
    public ShipMove Move => move;
    //플레이어 기체의 공격을 담당하는 클래스
    [SerializeField]
    private Module module;
    public Module Module => module;

    //현재 상태
    private IState state;
    public IState State { get { return state; } set { state?.ExitState(); state = value; state.EnterState(); } }
    //평번한 상태
    private NomalState nomalState;
    public NomalState NomalState => nomalState;
    //감속 상태
    private ShiftState shiftState;
    public ShiftState ShiftState => shiftState;

    void Start()
    {
        nomalState = new NomalState(nomalCollider, center, this);
        shiftState = new ShiftState(shiftCollider, center, this);
        State = nomalState;
    }

    void Update()
    {
        //아직 상태에서 update를 아무것도 하지 않지만 혹시 모르니 일단 만들어는 놨음
        state?.UpdateState();
    }

    //플레이어가 맞았을 경우 호출되는 메소드 여기서 목숨이 까지고 다시 기체를 생성하고 하는 부분이 들어가야 함
    public void Hit()
    {
        gameObject.SetActive(false);
        //Player.Instance.Ship = null;
        Player.Instance.Life -= 1;
        STGManager.Instance.StartCoroutine(Respawn());
    }

    private IEnumerator Respawn()
    {
        yield return new WaitForSeconds(0.8f);
        //Player.Instance.Ship = this;
        nomalCollider.enabled = false;
        shiftCollider.enabled = false;
        transform.position = InfoStatic.spawnPoint;
        gameObject.SetActive(true);
        SpriteRenderer spriteRenderer = animator.GetComponent<SpriteRenderer>();
        spriteRenderer.color = new Color(1, 1, 1, 0.5f);
        yield return new WaitForSeconds(0.8f);
        spriteRenderer.color = new Color(1, 1, 1, 1);
        state.Collider.enabled = true;
    }
}
