using UnityEngine;
using UnityEngine.UI;

public class BossHPUI : MonoBehaviour
{
    private static BossHPUI insatnce = null;
    public static BossHPUI Instance
    {
        get
        {
            insatnce = insatnce != null ? insatnce : FindFirstObjectByType<BossHPUI>();
            return insatnce;
        }
    }

    [SerializeField]
    private Image hp;
    [SerializeField]
    private GameObject back;
    private Boss boss;

    void Start()
    {
        insatnce = this;
    }

    // Update is called once per frame
    void Update()
    {
        if (boss == null)
            return;

        hp.fillAmount = boss.HP / boss.MaxHP;
    }

    public void SetBoss(Boss boss)
    {
        this.boss = boss;

        if (boss != null)
        {
            back.SetActive(true);
            hp.gameObject.SetActive(true);
        }
            
        else
        {
            back.SetActive(false);
            hp.gameObject.SetActive(false);
        }
            
    }
}
