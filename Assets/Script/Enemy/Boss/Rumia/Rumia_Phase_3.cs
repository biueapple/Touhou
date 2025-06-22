using UnityEngine;

[System.Serializable]
public class Rumia_Phase_3 : Phase
{
    public override void Enter()
    {
        boss.HP = boss.MaxHP;
        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance(boss);
        }
        boss.MoveObject.moveTypes = moveTypes[0].ToArray();
    }


    //int index = 0;
    public override void Excute()
    {
        if (boss.HP <= 0)
        {
            //���� ������� ���ٸ� Dead();
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

        if (patternDatas == null)
            return;

        //��� ������ ���ÿ� ����ϴ� ���
        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].timer += Time.deltaTime;
            if (patternDatas[i].timer >= patternDatas[i].fireDelay)
            {
                patternDatas[i].patternInstance.Fire(boss.transform); // ���� ��ġ���� �߻�
                patternDatas[i].timer = 0f;
            }
        }
    }

    public override void Exit()
    {

    }
}
