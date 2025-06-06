using UnityEngine;

//�÷��̾��� ��ü�� ����ϴ� ���� ��ũ��Ʈ
public class Attack : MonoBehaviour
{
    //�Ѿ˿� ���� ���� ��ũ���ͺ� ������Ʈ�� ������� ����
    [SerializeField]
    protected BulletData data;
    //�÷��̾ ȹ���� �Ŀ��� ����Ǵ� ���� maxDamage���� ������ ���� ������ currentDamage�� �ö�
    //���� ����� (�Ŀ�)
    [SerializeField]
    protected float currentDamage = 0;
    public float CurrentDamage { get { return currentDamage; } set { currentDamage = Mathf.Min(value, maxDamage); } }
    //������� �������� �� (�Ŀ� 1�� ���� ���������)
    [SerializeField]
    protected float magnifying = 1;
    public float Magnifying { get { return magnifying; } }
    //�ִ� �����
    [SerializeField]
    protected float maxDamage = 1;
    public float MaxDamage { get { return maxDamage; } }
    //������ ������
    [SerializeField]
    protected float delay = 0.1f;
    //������ �ð��� ��� Ÿ�̸�
    protected float timer;

    void Start()
    {
        //Ÿ�̸ӿ�
        timer = Time.time;
        //���� ����� �ʱ�ȭ
        currentDamage = 0; 
        //�� ������ ����� �Ѿ��� ������Ʈ Ǯ���� ����Ͽ� ����
        ObjectPooling.Instance.Registration(data.bulletId, data.bulletPrefab);
    }

    //�߻�
    public void Fire()
    {
        //������� 0�̰ų� ������ �ð� ���� �̴޼�
        if (currentDamage <= 0 || timer + delay > Time.time)
            return;

        //�¿쿡�� �ϳ��� �߻�
        CreateBullet(transform.position + new Vector3(-0.1f, 0, 0), currentDamage * magnifying, Vector3.up, 6);
        CreateBullet(transform.position + new Vector3(0.1f, 0, 0), currentDamage * magnifying, Vector3.up, 6);

        //Ÿ�̸� �缳��
        timer = Time.time;
    }

    //�Ѿ��� �����ϰ� �߻�
    private void CreateBullet(Vector3 position, float damage, Vector3 dir, float speed)
    {
        //�Ѿ��� �����ϰ� �߻��ϰ� �����ӱ��� ��������
        BulletManager.Instance.FireBullet(position, dir, damage, speed, data.bulletId);
    }

    //�Ŀ��� ������ �� �޼ҵ带 ȣ���� �����Ŵ
    public float AddDamage(float amount)
    {
        float space = maxDamage - currentDamage;
        float used = Mathf.Min(space, amount);
        currentDamage += used;
        return used;
    }
}
