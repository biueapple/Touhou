using System.Collections;
using UnityEngine;

//����� ��ü
public class Player_Ship : MonoBehaviour
{
    //����� ���°� ����� �ݶ��̴�
    [SerializeField]
    private Collider nomalCollider;
    public Collider NomalCollider { get => nomalCollider; }
    //����Ʈ�� ���� ���°� ����� �ݶ��̴�
    [SerializeField]
    private Collider shiftCollider;
    public Collider ShiftCollider { get => shiftCollider; }
    //����Ʈ�� ������ ��ü�� �߰� �κп� ���� ���� ���ܾ� �ؼ� �� �� ������Ʈ
    [SerializeField]
    private GameObject center;
    //���ϸ��̼�
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return animator; } }

    //�÷��̾� ��ü�� �������� �����Ű�� Ŭ����
    [SerializeField]
    private ShipMove move;
    public ShipMove Move => move;
    //�÷��̾� ��ü�� ������ ����ϴ� Ŭ����
    [SerializeField]
    private Module module;
    public Module Module => module;

    //���� ����
    private IState state;
    public IState State { get { return state; } set { state?.ExitState(); state = value; state.EnterState(); } }
    //����� ����
    private NomalState nomalState;
    public NomalState NomalState => nomalState;
    //���� ����
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
        //���� ���¿��� update�� �ƹ��͵� ���� ������ Ȥ�� �𸣴� �ϴ� ������ ����
        state?.UpdateState();
    }

    //�÷��̾ �¾��� ��� ȣ��Ǵ� �޼ҵ� ���⼭ ����� ������ �ٽ� ��ü�� �����ϰ� �ϴ� �κ��� ���� ��
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
