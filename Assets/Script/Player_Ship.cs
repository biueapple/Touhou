using UnityEngine;

public class Player_Ship : MonoBehaviour
{
    [SerializeField]
    private Collider nomalCollider;
    public Collider NomalCollider { get => nomalCollider; }
    [SerializeField]
    private Collider shiftCollider;
    public Collider ShiftCollider { get => shiftCollider; }
    [SerializeField]
    private GameObject center;
    [SerializeField]
    private Animator animator;
    public Animator Animator { get { return animator; } }

    [SerializeField]
    private Move move;
    public Move Move => move;
    [SerializeField]
    private Module module;
    public Module Module => module;

    private IState state;
    public IState State { get { return state; } set { state?.ExitState(); state = value; state.EnterState(); } }
    private NomalState nomalState;
    public NomalState NomalState => nomalState;
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
        state?.UpdateState();
    }

    private void OnTriggerEnter(Collider other)
    {
        
    }
}
