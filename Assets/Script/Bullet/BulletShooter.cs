using UnityEngine;

//���� �Ѿ��� �߻��� �� ����ϴ� Ŭ���� (������ ������� ���� ������ �������� �Ǹ� ������ �����ؼ�)
public class BulletShooter : MonoBehaviour
{
    public PatternData[] patternDatas = null;
    private Enemy enemy;

    private void Start()
    {
        enemy = GetComponent<Enemy>();
        if (patternDatas == null)
            return;

        for(int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].CreateInstance(enemy);
        }
    }

    //STGManager�� ������
    public void Tick()
    {
        if (patternDatas == null)
            return;

        for (int i = 0; i < patternDatas.Length; i++)
        {
            patternDatas[i].timer += Time.deltaTime;
            if (patternDatas[i].timer >= patternDatas[i].fireDelay)
            {
                patternDatas[i].patternInstance.Fire(transform); // ���� ��ġ���� �߻�
                patternDatas[i].timer = 0f;
            }
        }
    }
}
