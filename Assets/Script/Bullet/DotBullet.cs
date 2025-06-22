using UnityEngine;


public enum MotionType { Sin, Zigzag, Accelerate, Bounce, RandomDrift }

public class DotBullet : Bullet
{
    public MotionType motion;
    private float straight;

    public override void Initialize(Vector3 dir, float damage, AnimationCurve speed)
    {
        base.Initialize(dir, damage, speed);
        motion = (MotionType)Random.Range(0, System.Enum.GetValues(typeof(MotionType)).Length);
        straight = Random.Range(1f, 3f);
    }

    public override void Tick()
    {
        timeAlive += Time.deltaTime;

        Vector3 moveDir = direction; // �ܺο��� ���Ե� ���� ����

        switch (motion)
        {
            case MotionType.Sin:
                // ����� ������ ���ͷ� ��鸮�� �ϱ�
                Vector3 perp = Vector3.Cross(direction, Vector3.forward).normalized; // 2D ����
                moveDir += perp * Mathf.Sin(timeAlive * 5f) * 0.5f;
                break;

            case MotionType.Zigzag:
                Vector3 side = Vector3.Cross(direction, Vector3.forward).normalized;
                moveDir += side * (Mathf.PingPong(timeAlive * 3f, 1f) - 0.5f);
                break;

            case MotionType.Accelerate:
                straight += Time.deltaTime;
                break;

            case MotionType.Bounce:
                moveDir = direction; // �⺻ ����
                moveDir += Vector3.up * Mathf.Abs(Mathf.Sin(timeAlive * 3f)) * 0.5f;
                break;

            case MotionType.RandomDrift:
                Vector3 randomSide = Vector3.Cross(direction, Vector3.forward).normalized;
                moveDir += randomSide * Random.Range(-0.05f, 0.05f);
                break;
        }

        transform.position += moveDir.normalized * straight * Time.deltaTime;
    }
}
