using UnityEngine;

public class Move : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public Vector3 Velocity { get { return velocity; } set { velocity = value; } }
    private float speed;
    public float Speed { get => speed; set { speed = value; } }

    void Update()
    {
        move();
    }

    private void move()
    {
        transform.position += speed * Time.deltaTime * velocity;
        transform.position = new Vector2(Mathf.Clamp(transform.position.x, -InfoStatic.MapSize.x, InfoStatic.MapSize.x), Mathf.Clamp(transform.position.y, -InfoStatic.MapSize.y, InfoStatic.MapSize.y));
        velocity = Vector3.zero;
    }
}
