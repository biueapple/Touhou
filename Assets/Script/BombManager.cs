using System.Collections;
using UnityEngine;

public class BombManager : MonoBehaviour
{
    private static BombManager instance;
    public static BombManager Instance { get => instance; }

    public GameObject image;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Bomb()
    {
        //���� ��ź�� ���ٸ� �۵����� ����
        if (Player.Instance.Bomb <= 0 || image.activeSelf)
            return;
        //�̹����� ���� Ŀ���鼭 ������ ź�� ���ְ� ��� ���鿡�� �����
        image.transform.position = Player.Instance.Ship.transform.position;
        image.transform.localScale = new Vector3(0, 0, 0);
        image.SetActive(true);
        StartCoroutine(enumerator());
        Player.Instance.Bomb -= 1;
    }

    private IEnumerator enumerator()
    {
        float size = 0;

        while(size < 30)
        {
            size += Time.deltaTime * 10;
            image.transform.localScale = new Vector3(size, size);
            
            //layer�� enemy�� bullet�� Enemy, STGManager bulletmanager
            for (int i = STGManager.Instance.Enemies.Count - 1; i >= 0; i--)
            {
                if(Vector2.Distance(image.transform.position, STGManager.Instance.Enemies[i].transform.position) <= size * 0.5f)
                {
                    STGManager.Instance.Enemies[i].HP -= 10;
                }
            }
            for (int i = BulletManager.Instance.ActiveBullets.Count - 1; i >= 0; i--)
            {
                if (BulletManager.Instance.ActiveBullets[i].gameObject.layer == LayerMask.NameToLayer("Enemy"))
                {
                    if (Vector2.Distance(image.transform.position, BulletManager.Instance.ActiveBullets[i].transform.position) <= size * 0.5f)
                    {
                        BulletManager.Instance.UnregisterBullet(BulletManager.Instance.ActiveBullets[i]);
                    }
                }
            }
            yield return null;
        }
        image.SetActive(false);
    }
}
