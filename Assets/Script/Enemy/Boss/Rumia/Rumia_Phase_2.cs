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
        //������ ������� ����ϱ� ���� �غ�
        //patternDatas[0].timer = patternDatas[0].fireDelay;
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

        //���� �ð����� �����ϰ� �̵� (0��°�� ������� ����)
        moveTimer += Time.deltaTime;
        if (moveTimer >= moveTime)
        {
            boss.MoveObject.moveTypes = moveTypes[Random.Range(0, moveTypes.Length)].ToArray();
            boss.MoveObject.currentPathIndex = 0;
            moveTimer = 0;
        }


        if (patternDatas == null)
            return;

        //������ ������� ���
        //if (index >= patternDatas.Length)
        //    index = 0;

        //patternDatas[index].timer += Time.deltaTime;
        //if (patternDatas[index].timer >= patternDatas[index].fireDelay)
        //{
        //    patternDatas[index].patternInstance.Fire(boss.transform); // ���� ��ġ���� �߻�
        //    patternDatas[index].timer = 0f;
        //    index++;
        //}


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
