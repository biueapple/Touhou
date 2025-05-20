using System.Collections.Generic;
using UnityEngine;

public class ItemCollector : MonoBehaviour
{
    private readonly List<Item> list = new();

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Item item) && !list.Contains(item))
        {
            list.Add(item);
        }
    }

    private void Update()
    {
        for (int i = list.Count - 1; i >= 0; i--)
        {
            if(Vector2.Distance(transform.position, list[i].transform.position) < 0.1f)
            {
                Acquisition(list[i]);
                list.RemoveAt(i);
                continue;
            }
            list[i].transform.position += InfoStatic.PullSpeed * Time.deltaTime * (transform.position - list[i].transform.position).normalized;
        }
    }

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
                Player.Instance.Score += 1;
                break;
            case ITEMTYPE.POINT10:
                Player.Instance.Score += 10;
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
