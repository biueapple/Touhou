using UnityEngine;

//아이템의 종류
public enum ITEMTYPE
{
    POWER1,
    POWER10,
    POINT1,
    POINT10,
    LIFE,
    BOMB,

}

public class Item : MonoBehaviour
{
    //무슨 아이템인지
    [SerializeField]
    private ITEMTYPE type;
    public ITEMTYPE Type { get { return type; } }

    private void Update()
    {
        //중력을 적용
        transform.position += InfoStatic.Gravity * Time.deltaTime * Vector3.down;
    }
}
