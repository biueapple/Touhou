using System.Collections.Generic;
using UnityEngine;

//�÷��̾� ��ü�� ������ �ִ� ������ ������
public class ItemCollector : MonoBehaviour
{
    //��ó�� �� ������
    private readonly List<Item> list = new();

    //��� ���� ��������� �浹�ϵ��� ������ ����
    private void OnTriggerEnter(Collider other)
    {
        //������� ������ ����Ʈ�� ���
        if(other.TryGetComponent(out Item item) && !list.Contains(item))
        {
            list.Add(item);
        }
    }

    private void Update()
    {
        //������� �������� �÷��̾� ��ü ��ġ�� ��ƴ��� ����� ��������� ȹ��
        for (int i = list.Count - 1; i >= 0; i--)
        {
            //�Ÿ�üũ
            if(Vector2.Distance(transform.position, list[i].transform.position) < 0.1f)
            {
                //ȹ��
                Acquisition(list[i]);
                list.RemoveAt(i);
                continue;
            }
            //��ƴ���
            list[i].transform.position += InfoStatic.PullSpeed * Time.deltaTime * (transform.position - list[i].transform.position).normalized;
        }
    }

    //�������� ȹ���ϸ� ȿ���� �ް� ���������
    private void Acquisition(Item item)
    {
        switch (item.Type)
        {
            case ITEMTYPE.POWER1:
                Player.Instance.AddPower(0.1f);
                break;
            case ITEMTYPE.POWER10:
                Player.Instance.AddPower(1f);
                break;
            case ITEMTYPE.POINT1:
                ScoreManager.Instance.Add(InfoStatic.point1);
                break;
            case ITEMTYPE.POINT10:
                ScoreManager.Instance.Add(InfoStatic.point10);
                break;
            case ITEMTYPE.LIFE:
                Player.Instance.Life += 1;
                break;
            case ITEMTYPE.BOMB:
                Player.Instance.Bomb += 1;
                break;
        }
        item.gameObject.SetActive(false);
    }
}
