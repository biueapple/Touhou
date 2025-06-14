using System.Collections.Generic;
using UnityEngine;

//아이템을 활성화 비활성화 해주는 클래스
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

    //존재하는 아이템 종류
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

    //활성화 상태의 아이템들
    private List<Item> activeItems = new();
    private Dictionary<string, Queue<Item>> dictionary = new();

    private void Update()
    {
        activeItems.ForEach(x => x.transform.position += InfoStatic.Gravity * Time.deltaTime * Vector3.down);
    }

    private void Start()
    {
        //풀링에 아이템 등록 (pooling 은 총알만 만들어져 있는 김에 여기서 해결해야겠다)
        //key값은 아이템이 가진 enum 과 동일
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


