using UnityEngine;

//homing�̶� ź�� �ٸ���
//[CreateAssetMenu(menuName = "BulletPattern/DelayedClone")]
public class DelayedClonePattern : BulletPattern
{
    //������ ����
    public override PatternInstance CreateInstance(Enemy enemy)
    {
        return new DelayedCloneInstance(this, enemy);
    }
}

//���� �۵��ϴ� Ŭ����
public class DelayedCloneInstance : PatternInstance
{
    //�ڽ��� ������ ������Ʈ (������Ʈ ������ ������� �۵��ϱ⿡)
    private readonly DelayedClonePattern pattern;

    public DelayedCloneInstance(DelayedClonePattern pattern, Enemy _)
    {
        this.pattern = pattern;
    }

    //���� �߻� �÷��̾�� �߻�
    public override void Fire(Transform firePoint)
    {
        
    }
}