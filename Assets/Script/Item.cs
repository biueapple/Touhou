using UnityEngine;

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
    [SerializeField]
    private ITEMTYPE type;
    public ITEMTYPE Type { get { return type; } }

    private void Update()
    {
        transform.position += InfoStatic.Gravity * Time.deltaTime * Vector3.down;
    }
}
