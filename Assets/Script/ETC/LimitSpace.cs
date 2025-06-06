using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class LimitSpace : MonoBehaviour
{
    //�����۰� �Ѿ��� ������ �����ϴ� �ݶ��̴� (����� ��Ȱ��ȭ)
    [SerializeField]
    private BoxCollider box;
    //������ ������ ���ϵ��� �����ϴ� �ݶ��̴� (�÷��̾� ��ü�� ������ ���ϵ��� ���� ������ ��Ȱ��ȭ �ǵ���)
    [SerializeField]
    private BoxCollider unitLimit;
    //�÷��̾� ��ü
    private Player_Ship ship;

    private void Update()
    {
        //�÷��̾ ������ �ݶ��̴��� ���ٸ�
        if (unitLimit == null)
            return;

        //�÷��̾ ���ٸ�
        if(ship == null)
        {
            ship = Player.Instance.Ship;
            //�������� ������ �������� �Ѱܵ� ������ ���� (Ȥ�� �÷��̾� ��ü�� null�ϼ��� ������)
            return;
        }    

        //��ġ�� ����
        ship.transform.position = new Vector3(Mathf.Clamp(ship.transform.position.x, unitLimit.center.x - unitLimit.size.x * 0.5f, unitLimit.center.x + unitLimit.size.x * 0.5f),
                                                   Mathf.Clamp(ship.transform.position.y, unitLimit.center.y - unitLimit.size.y * 0.5f, unitLimit.center.y + unitLimit.size.y * 0.5f));
    }

    
    private void OnTriggerEnter(Collider other)
    {
        //���� ���� ������ ���� (unitLimit�ϰ� �浹�ϵ��� ����������)
        if (other.TryGetComponent(out Enemy enemy))
        {
            //���� Ȱ��ȭ (������ �߻� ������ ����)
            STGManager.Instance.Enemies.Add(enemy);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //�Ѿ��� ���� �ٱ����� ���� (box collider)
        if (other.TryGetComponent(out Bullet bullet))
        {
            //�Ѿ� ��Ȱ��ȭ
            bullet.ReturnToPool();
        }
        //�������� ���� �ٱ����� ���� (box collider)
        else if (other.TryGetComponent(out Item item))
        {
            //������ ��Ȱ��ȭ
            item.gameObject.SetActive(false);
        }
        //���� ���� �ٱ����� ���� (unitLimit collider)
        else if(other.TryGetComponent(out Enemy enemy))
        {
            //���� ��Ȱ��ȭ
            STGManager.Instance.Enemies.Remove(enemy);
            enemy.gameObject.SetActive(false);
        }
    }
}
