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
            //���� ������� ���ٸ� Dead();
        }

        //���� �ð����� �����ϰ� �̵� (0��°�� ������� ����)

        //������ ������� ���

    }

    public override void Exit()
    {

    }
}
