using UnityEngine;

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

    private IPlayMode playMode;
    public IPlayMode PlayMode { get { return playMode; } set { playMode = value; } }

    //파워를 회득 시 호출
    public void AddPower(float amount)
    {
        if (ship == null)
            return;

        //파워의 최대치는 5
        if (power + amount > 5)
            amount = 5 - power;

        Power += amount;

        foreach (var weapon in ship.Module.Weapons)
        {
            if (amount <= 0) break;
            float used = weapon.AddDamage(amount);
            amount -= used;
        }
    }

    public void PowerInit()
    {
        if (ship != null)
            foreach (var weapon in ship.Module.Weapons)
                weapon.CurrentDamage = 0;
    }

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        //기체가 없다면 아무것도 하지 않음
        if (ship == null)
            return;

        playMode?.Update();
    }

    //playMode로 받은 입력을 적용시키는 메소드
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

    //플레이어와의 상대적인 방향을 리턴
    public Vector3 RelativeDirection(Transform transform)
    {
        if(ship == null)
            return Vector3.zero;
        return ship.transform.position - transform.position;
    }
}
