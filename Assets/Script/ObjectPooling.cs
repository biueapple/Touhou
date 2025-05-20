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
    private readonly LinkedList<(Bullet, float)> destroy = new();


    public Bullet CreateBullet(int hash)
    {
        Bullet bullet = dictionary[hash].Dequeue();
        bullet.gameObject.SetActive(true);
        dictionary[hash].Enqueue(bullet);
        return bullet;
    }

    public void DestroyBullet(Bullet bullet, float timer = 0)
    {
        if(timer == 0)
        {
            bullet.gameObject.SetActive(false);
        }
        else
        {
            destroy.AddLast((bullet, timer + Time.time));
        }
    }

    public void Registration<T>(int hash, Bullet b, int count = 300)
    {
        dictionary[hash] = new();
        for (int i = 0; i < count; i++)
        {
            Bullet bullet = Instantiate(b, transform);
            bullet.gameObject.SetActive(false);
            dictionary[hash].Enqueue(bullet);
        }
    }

    private void Update()
    {
        while(destroy.Count > 0)
        {
            var (bullet, t) = destroy.First.Value;
            if (t > Time.time)
                break;
            bullet.gameObject.SetActive(false);
            destroy.RemoveFirst();
        }
    }
}

public class ListDictionary<T>
{
    private readonly Dictionary<int, List<T>> internalDict = new();

    public void Add(int key, T item)
    {
        if (!internalDict.ContainsKey(key))
            internalDict[key] = new List<T>();
        internalDict[key].Add(item);
    }

    public List<T> Get(int key)
    {
        return internalDict.TryGetValue(key, out var list) ? list : new List<T>();
    }

    public bool ContainsKey(int key) => internalDict.ContainsKey(key);
    public void Clear() => internalDict.Clear();
    public Dictionary<int, List<T>> Raw => internalDict; // 직접 접근도 허용
}