using UnityEngine;

//플레이어 기체만 사용하는 적을 실시간으로 쫒아가는 유도탄 (적이 발사하면 피하기가 어려우니)
public class HomingBullet : Bullet
{
    public override void Tick()
    {
        //가장 가까운 적을 리턴받음
        Enemy enemy = STGManager.Instance.NearEnemy(transform.position);
        if(enemy != null)
        {
            //각도 계산 과정
            Vector2 forward = transform.up; // 총알이 보는 방향
            Vector2 toTarget = (enemy.transform.position - transform.position).normalized;
            
            float cross = forward.x * toTarget.y - forward.y * toTarget.x;
            if (cross > 0)
                transform.eulerAngles += InfoStatic.HomingRotateSpeed * Time.deltaTime * Vector3.forward;
            else if(cross < 0) 
                transform.eulerAngles -= InfoStatic.HomingRotateSpeed * Time.deltaTime * Vector3.forward;
        }

        // 전방 방향으로 이동
        transform.position +=  Speed * Time.deltaTime * transform.up;
    }
}
