using UnityEngine;

public class ShipMove : MonoBehaviour
{
    private Vector3 velocity = Vector3.zero;
    public Vector3 Velocity { get { return velocity; } set { velocity = value.normalized; } }
    [SerializeField]
    private float speed;
    public float Speed { get => speed; set { speed = value; } }
    [SerializeField]
    private Animator animator;

    void Update()
    {
        Move();
    }

    private void Move()
    {
        velocity = speed * Time.deltaTime * velocity;
        if (velocity.x > 0f)
            animator.SetInteger("Move", 1); //right
        else if (velocity.x < 0f)
            animator.SetInteger("Move", 2);    //left
        else
            animator.SetInteger("Move", 0);
        transform.position += velocity;
        velocity = Vector3.zero;
    }
}
