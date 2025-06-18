using System.Collections.Generic;
using UnityEngine;

//플레이어 기체가 가지고 있는 아이템 수집기
public class ItemCollector : MonoBehaviour
{
    //근처로 온 아이템
    private readonly List<Item> list = new();

    //어느 정도 가까워지면 충돌하도록 범위를 잡음
    private void OnTriggerEnter(Collider other)
    {
        //가까워진 아이템 리스트에 등록
        if(other.TryGetComponent(out Item item) && !list.Contains(item))
        {
            list.Add(item);
        }
    }

    private void Update()
    {
        //가까워진 아이템은 플레이어 기체 위치로 잡아당기고 충분히 가까워지면 획득
        for (int i = list.Count - 1; i >= 0; i--)
        {
            //거리체크
            if(Vector2.Distance(transform.position, list[i].transform.position) < 0.1f)
            {
                //획득
                Acquisition(list[i]);
                list.RemoveAt(i);
                continue;
            }
            //잡아당기기
            list[i].transform.position += InfoStatic.PullSpeed * Time.deltaTime * (transform.position - list[i].transform.position).normalized;
        }
    }

    //아이템을 획득하면 효과를 받고 사라지도록
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
