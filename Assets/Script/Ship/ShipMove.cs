using UnityEngine;

public class ShipMove : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }
    [SerializeField]
    private float speed;
    public float Speed { get => speed; set { speed = value; } }

    void Update()
    {
        Move();
    }

    private void Move()
    {
        transform.position += speed * Time.deltaTime * velocity;
        velocity = Vector3.zero;
    }
}
