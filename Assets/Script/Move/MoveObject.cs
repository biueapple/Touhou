using UnityEngine;

//여러 이동 패턴을 이용해야 움직이는 클래스
public class MoveObject : MonoBehaviour
{
    //가지고 있는 움직임 패턴들
    public MoveType[] moveTypes;

    //현재 적용되고 있는 움직임 패턴
    [SerializeField]
    public int currentPathIndex = 0;

    //기체를 실제로 움직이게 해주는 클래스
    private ShipMove move;

    //움직임 패턴이 보고 참고할 인덱스 (현재 이 오브젝트가 어디까지 갔는지 {float인 이유는 wait타입이 어느정도 멈춰있었는지에 대한 타이머로도 사용하기 때문})
    [SerializeField]
    private float index = 0;
    public float Index { get { return index; } set { index = value; } }
    //이 오브젝트의 속도
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
        //움직임에 대한 방향을 받아
        Vector3 newPosition = moveTypes[currentPathIndex].GetPath(this);
        Vector3 direction = (newPosition - transform.position);
        direction.z = 0f;
        //실제 움직이게 해주는 클래스에 전달
        move.Velocity = direction;
    }

    //다음 움직임 패턴 적용
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
