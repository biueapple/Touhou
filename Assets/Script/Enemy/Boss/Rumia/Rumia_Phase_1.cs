using UnityEngine;

[System.Serializable]
public class Rumia_Phase_1 : Phase
{


    public override void Enter()
    {
        //boss.BulletShooter.PatternInstance = patternInstances[0];
        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance();
        }
        boss.BulletShooter.patternDatas = patternDatas;
    }

    public override void Excute()
    {
        if(boss.HP <= 0)
        {
            //다음 페이즈로 없다면 Dead();
        }

        //일정 시간마다 랜덤하게 이동 (0번째는 사용하지 않음)

        //패턴을 순서대로 사용

    }

    public override void Exit()
    {

    }
}
