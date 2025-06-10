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

    //���
    private int life;
    public int Life { get => life; set { life = value; } }
    //��ź
    private int bomb;
    public int Bomb { get => bomb; set { bomb = value; } }
    //����
    private int score;
    public int Score { get => score; set { score = value; } }
    //�Ŀ�
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

    //��ü
    [SerializeField]
    private Player_Ship ship;
    public Player_Ship Ship { get { return ship; } set { ship = value; } }

    private IPlayMode playMode;
    public IPlayMode PlayMode { get { return playMode; } set { playMode = value; } }

    //�Ŀ��� ȸ�� �� ȣ��
    public void AddPower(float amount)
    {
        if (ship == null)
            return;

        //�Ŀ��� �ִ�ġ�� 5
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
        //��ü�� ���ٸ� �ƹ��͵� ���� ����
        if (ship == null)
            return;

        playMode?.Update();
    }

    //playMode�� ���� �Է��� �����Ű�� �޼ҵ�
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

    //�÷��̾���� ������� ������ ����
    public Vector3 RelativeDirection(Transform transform)
    {
        if(ship == null)
            return Vector3.zero;
        return ship.transform.position - transform.position;
    }
}
