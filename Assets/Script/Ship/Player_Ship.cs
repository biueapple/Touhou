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

    }
}
