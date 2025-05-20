using UnityEngine;

public class HomingBullet : Bullet
{
    private void Update()
    {
        Enemy enemy = STGManager.Instance.NearEnemy(transform.position);
        if(enemy != null)
        {
            Vector2 forward = transform.up; // 총알이 보는 방향
            Vector2 toTarget = (enemy.transform.position - transform.position).normalized;

            float cross = forward.x * toTarget.y - forward.y * toTarget.x;
            if (cross > 0)
                transform.eulerAngles += InfoStatic.HomingRotateSpeed * Time.deltaTime * Vector3.forward;
            else if(cross < 0) 
                transform.eulerAngles -= InfoStatic.HomingRotateSpeed * Time.deltaTime * Vector3.forward;
        }

        // 전방 방향으로 이동 (총알의 정면이 X+이라고 가정)
        transform.position +=  Speed * Time.deltaTime * transform.up;
    }
}
