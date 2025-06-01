using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ObjectPooling : MonoBehaviour
{
    private static ObjectPooling instance;
    public static ObjectPooling Instance
    {
        get
        {
            instance = instance != null ? instance : FindFirstObjectByType<ObjectPooling>();
            instance = instance != null ? instance : new GameObject("ObjectPooling").AddComponent<ObjectPooling>();
            return instance;
        }
    }

    private readonly Dictionary<int, Queue<Bullet>> dictionary = new ();


    public Bullet CreateBullet(int hash)
    {
        if (!dictionary.ContainsKey(hash) || dictionary[hash].Count == 0)
            return null;
        Bullet bullet = dictionary[hash].Dequeue();
        bullet.gameObject.SetActive(true);
        return bullet;
    }

    public void DestroyBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
        dictionary[bullet.Hash].Enqueue(bullet);
    }

    public void Registration(int hash, Bullet b, int count = 300)
    {
        dictionary[hash] = new();
        for (int i = 0; i < count; i++)
        {
            Bullet bullet = Instantiate(b, transform);
            bullet.Hash = hash;
            bullet.gameObject.SetActive(false);
            dictionary[hash].Enqueue(bullet);
        }
    }
}

//public class ListDictionary<T>
//{
//    private readonly Dictionary<int, List<T>> internalDict = new();

//    public void Add(int key, T item)
//    {
//        if (!internalDict.ContainsKey(key))
//            internalDict[key] = new List<T>();
//        internalDict[key].Add(item);
//    }

//    public List<T> Get(int key)
//    {
//        return internalDict.TryGetValue(key, out var list) ? list : new List<T>();
//    }

//    public bool ContainsKey(int key) => internalDict.ContainsKey(key);
//    public void Clear() => internalDict.Clear();
//    public Dictionary<int, List<T>> Raw => internalDict; // 직접 접근도 허용
//}