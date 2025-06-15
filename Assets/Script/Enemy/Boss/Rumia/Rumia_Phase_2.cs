using UnityEngine;

[System.Serializable]
public class Rumia_Phase_2 : Phase
{
    public override void Enter()
    {
        boss.HP = boss.MaxHP;
        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance(boss);
        }
        //boss.BulletShooter.patternDatas = patternDatas;
        //패턴을 순서대로 사용하기 위한 준비
        //patternDatas[0].timer = patternDatas[0].fireDelay;
    }


    //int index = 0;
    public override void Excute()
    {
        if (boss.HP <= 0)
        {
            //다음 페이즈로 없다면 Dead();
            if (next != null)
            {
                boss.Now = next;
            }
            else
            {
                BossHPUI.Instance.SetBoss(null);
                boss.Dead();
            }
        }

        //일정 시간마다 랜덤하게 이동 (0번째는 사용하지 않음)
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveTime)
        {
            boss.MoveObject.moveTypes = moveTypes[Random.Range(0, moveTypes.Length)].ToArray();
            boss.MoveObject.currentPathIndex = 0;
            moveTimer = 0;
        }


        if (patternDatas == null)
            return;

        //패턴을 순서대로 사용
        //if (index >= patternDatas.Length)
        //    index = 0;

        //patternDatas[index].timer += Time.deltaTime;
        //if (patternDatas[index].timer >= patternDatas[index].fireDelay)
        //{
        //    patternDatas[index].patternInstance.Fire(boss.transform); // 현재 위치에서 발사
        //    patternDatas[index].timer = 0f;
        //    index++;
        //}


        //모든 패턴을 동시에 사용하는 방법
        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].timer += Time.deltaTime;
            if (patternDatas[i].timer >= patternDatas[i].fireDelay)
            {
                patternDatas[i].patternInstance.Fire(boss.transform); // 현재 위치에서 발사
                patternDatas[i].timer = 0f;
            }
        }
    }

    public override void Exit()
    {

    }
}
