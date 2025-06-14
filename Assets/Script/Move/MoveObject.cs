using UnityEngine;

//���� �̵� ������ �̿��ؾ� �����̴� Ŭ����
public class MoveObject : MonoBehaviour
{
    //������ �ִ� ������ ���ϵ�
    public MoveType[] moveTypes;

    //���� ����ǰ� �ִ� ������ ����
    [SerializeField]
    public int currentPathIndex = 0;

    //��ü�� ������ �����̰� ���ִ� Ŭ����
    private ShipMove move;

    //������ ������ ���� ������ �ε��� (���� �� ������Ʈ�� ������ ������ {float�� ������ waitŸ���� ������� �����־������� ���� Ÿ�̸ӷε� ����ϱ� ����})
    [SerializeField]
    private float index = 0;
    public float Index { get { return index; } set { index = value; } }
    //�� ������Ʈ�� �ӵ�
    public float Speed { get { return move.Speed; } }

    private void Start()
    {
        move = GetComponent<ShipMove>();
    }

    private void Update()
    {
        if (moveTypes == null)
            return;
        if (Arrival())
            return;
        //�����ӿ� ���� ������ �޾�
        Vector3 newPosition = moveTypes[currentPathIndex].GetPath(this);
        Vector3 direction = (newPosition - transform.position);
        direction.z = 0f;
        //���� �����̰� ���ִ� Ŭ������ ����
        move.Velocity = direction;
    }

    //���� ������ ���� ����
    public void SetNextPath()
    {
        currentPathIndex++;
        index = 0;
    }

    public void SetMoveType(MoveType[] moveTypes)
    {
        this.moveTypes = moveTypes;
        index = 0;
        currentPathIndex = 0;
    }

    public bool Arrival()
    {
        if (currentPathIndex >= moveTypes.Length)
            return true;
        return false;
    }
}
