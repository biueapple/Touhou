using UnityEngine;

[System.Serializable]
public class Rumia_Phase_1 : Phase
{
    public override void Enter()
    {
        boss.HP = boss.MaxHP;
        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance();
        }
    }

    public override void Excute()
    {
        if(boss.HP <= 0)
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

        //���� �ð����� �����ϰ� �̵� (0��°�� ������� ����)
        moveTimer += Time.deltaTime;
        if (moveTimer >= 5)
        {
            boss.MoveObject.moveTypes = moveTypes[Random.Range(0, moveTypes.Length)].ToArray();
            boss.MoveObject.currentPathIndex = 0;
            moveTimer = 0;
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
