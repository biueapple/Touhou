using System.Collections.Generic;
using UnityEngine;

//�������� Ȱ��ȭ ��Ȱ��ȭ ���ִ� Ŭ����
public class ItemManager : MonoBehaviour
{
    private static ItemManager instance;
    public static ItemManager Instance
    {
        get
        {
            instance = instance != null ? instance : FindFirstObjectByType<ItemManager>();
            instance = instance != null ? instance : new GameObject("ItemManager").AddComponent<ItemManager>();
            return instance;
        }
    }

    //�����ϴ� ������ ����
    [SerializeField]
    private Item power1;
    [SerializeField]
    private Item power10;
    [SerializeField]
    private Item point1;
    [SerializeField]
    private Item point10;
    [SerializeField]
    private Item life;
    [SerializeField]
    private Item bomb;

    //Ȱ��ȭ ������ �����۵�
    private List<Item> activeItems = new();
    private Dictionary<string, Queue<Item>> dictionary = new();

    private void Update()
    {
        activeItems.ForEach(x => x.transform.position += InfoStatic.Gravity * Time.deltaTime * Vector3.down);
    }

    private void Start()
    {
        //Ǯ���� ������ ��� (pooling �� �Ѿ˸� ������� �ִ� �迡 ���⼭ �ذ��ؾ߰ڴ�)
        //key���� �������� ���� enum �� ����
        RegistItem("POWER1", power1, 100);
        RegistItem("POWER10", power10, 30);
        RegistItem("POINT1", point1, 500);
        RegistItem("POINT10", point10, 50);
        RegistItem("LIFE", life, 5);
        RegistItem("BOMB", bomb, 5);
    }

    public void CreateItem(string key, Vector3 position)
    {
        Item item = dictionary[key].Dequeue();
        item.transform.position = position;
        activeItems.Add(item);
        item.gameObject.SetActive(true);
    }

    public void DestroyItem(Item item, string key)
    {
        dictionary[key].Enqueue(item);
        activeItems.Remove(item);
        item.gameObject.SetActive(false);
    }

    public void RegistItem(string key, Item prefab, int count)
    {
        dictionary[key] = new();
        Item item;
        for(int i = 0; i < count; i++)
        {
            item = Instantiate(prefab, transform);
            item.gameObject.SetActive(false);
            dictionary[key].Enqueue(item);
        }
    }
}


