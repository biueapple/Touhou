
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
                    instance = new GameObject("Player").AddComponent<Player>();
            }
                
            return instance;
        }
    }

    //格见
    private int life;
    public int Life { get => life; set { life = value; } }
    //气藕
    private int bomb;
    public int Bomb { get => bomb; set { bomb = value; } }
    //痢荐
    private int score;
    public int Score { get => score; set { score = value; } }
    //颇况
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

    [SerializeField]
    private Player_Ship ship;
    public Player_Ship Ship { get { return ship; } set { ship = value; } }
    [SerializeField]
    private Replay replay;
    public bool record = true;

    public void AddPower(float amount)
    {
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

    void Start()
    {
        instance = this;
    }

    void Update()
    {
        if (ship == null)
            return;

        if (record)
        {
            Enter();
            if (Input.GetKeyDown(KeyCode.LeftShift))
                ship.State = ship.ShiftState;
            if (Input.GetKeyUp(KeyCode.LeftShift))
                ship.State = ship.NomalState;

            if (Input.GetKey(KeyCode.Z))
            {
                ship.Module?.Fire();
            }
            replay?.RecordInput();
        }   
        else
        {
            replay?.PlaybackInput();
        }
    }

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

    public void Enter()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        if (horizontal > 0)
            ship.Animator.SetTrigger("Right");
        else if (horizontal < 0)
            ship.Animator.SetTrigger("Left");
        else
            ship.Animator.SetTrigger("Idle");
        float vertical = Input.GetAxisRaw("Vertical");
        ship.Move.Velocity = new Vector3(horizontal, vertical, 0);
    }
}
