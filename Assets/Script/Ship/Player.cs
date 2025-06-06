
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;
using static UnityEngine.ParticleSystem;

public class Player : MonoBehaviour
{
    private static Player instance;
    public static Player Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindFirstObjectByType<Player>();
                if (instance == null)
                {
                    instance = new GameObject("Player").AddComponent<Player>();
                }
            }
            return instance;
        }
    }

    //목숨
    private int life;
    public int Life { get => life; set { life = value; } }
    //폭탄
    private int bomb;
    public int Bomb { get => bomb; set { bomb = value; } }
    //점수
    private int score;
    public int Score { get => score; set { score = value; } }
    //파워
    [SerializeField]
    private float power;
    public float Power
    {
        get { return power; }
        set
        {
            power = Mathf.Min(value, 5);
        }
    }

    //기체
    [SerializeField]
    private Player_Ship ship;
    public Player_Ship Ship { get { return ship; } set { ship = value; } }

    //리플레이 (수정 필요)
    [SerializeField]
    private Replay replay;
    public bool record = true;

    //파워를 회득 시 호출
    public void AddPower(float amount)
    {
        //파워의 최대치는 5
        if (power + amount > 5)
        {
            amount = 5 - power;
        }
        Power += amount;
        if (ship != null)
        {
            foreach (var weapon in ship.Module.Weapons)
            {
                if (amount <= 0) break;
                float used = weapon.AddDamage(amount);
                amount -= used;
            }
        }
    }

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        //기체가 없다면 아무것도 하지 않음
        if (ship == null)
        {
            return;
        }

        //이 구간을 사용자 입력으로 받든 리플레이로 인해 받든 적용되도록 수정이 필요한 구간

        //리플레이 기록중 (정상 플레이중)
        if (record)
        {
            //움직임 키 입력 받아서 적용
            Enter();
            //상태변화 키 입력 받아서 적용
            if (Input.GetKeyDown(KeyCode.LeftShift))
            {
                ship.State = ship.ShiftState;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                ship.State = ship.NomalState;
            }

            //공격 입력 받아서 적용
            if (Input.GetKey(KeyCode.Z))
            {
                if (ship.Module != null)
                {
                    ship.Module.Fire();
                }
            }
            if(replay != null)
                replay.RecordInput();
        }
        //리플레이 기록중이지 않음 (리플레이 재생중)
        else
        {
            if (replay != null)
                replay.PlaybackInput();
        }
    }

    //리플레이로 받은 입력을 적용시키는 메소드
    public void ApplyInput(FrameInput frameInput)
    {
        Vector3 velocity = Vector3.zero;
        if (frameInput.Down)
            velocity += Vector3.down;
        if (frameInput.Up)
            velocity += Vector3.up;
        if (frameInput.Left)
            velocity += Vector3.left;
        if (frameInput.Right)
            velocity += Vector3.right;
        if (frameInput.Fire)
            ship.Module.Fire();
        if (frameInput.ShiftUp)
            ship.State = ship.NomalState;
        if (frameInput.ShiftDown)
            ship.State = ship.ShiftState;
        ship.Move.Velocity = velocity;
    }

    //움직임에 대한 키 입력을 받는 메소드
    public void Enter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        ship.Move.Velocity = new Vector3(horizontal, vertical, 0);
    }
}
