using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

//ui�� ��������� �����Ǿ ���� ����������� �ʴ� ��ũ��Ʈ �����Ƽ� ��� ui�� ���⼭ �����Ϸ��� ������ ���� �����°� �´µ�
public class STGMain : MonoBehaviour
{
    private static STGMain insatnce = null;
    public static STGMain Instance
    {
        get
        {
            insatnce = insatnce != null ? insatnce : FindFirstObjectByType<STGMain>();
            insatnce = insatnce != null ? insatnce : new GameObject("STGMain").AddComponent<STGMain>();
            return insatnce;
        }
    }

    [SerializeField]
    private GameObject mainmenu;
    [SerializeField]
    private GameObject[] panelUI;
    //���� ���� ��ư ����
    [SerializeField]
    private TextMeshProUGUI start;
    //����Ʈ�� �������� ���� ��ư (ó������ ������ �ʾƾ� �� {����Ʈ�� ���������� �������� �𸣰���})
    [SerializeField]
    private TextMeshProUGUI extra;
    //���÷��� �ٽú��� ��ư
    [SerializeField]
    private TextMeshProUGUI replay;
    //���� ���� ��ư
    [SerializeField]
    private TextMeshProUGUI score;
    //������ �ٽ� ���� �� �ִ� ����
    [SerializeField]
    private TextMeshProUGUI music;
    //�ɼ��� �����ϴ� ����
    [SerializeField]
    private TextMeshProUGUI option;
    //���� ����
    [SerializeField]
    private TextMeshProUGUI exit;
    //�ϴ��� �׽�Ʈ �뵵
    [SerializeField]
    private Player_Ship ship;

    [SerializeField]
    private GameObject powerUI;
    [SerializeField]
    private GameObject lifeUI;
    [SerializeField]
    private GameObject bombUI;
    [SerializeField]
    private GameObject scoreUI;

    //��� ��ư��� ����� ��Ī���ѳ��� ��ư�� onclick�� ������� ���� ������ �׳� �̰� �� ���ؼ�
    private readonly Dictionary<TextMeshProUGUI, Action> dictionary = new();
    //���� �������� �޴�
    private TextMeshProUGUI select = null;
    //�ε����δ� �̰�
    private int index = 0;
    //��Ȱ��ȭ alpha��
    private readonly float alpha = 0.4901961f;


    [SerializeField]
    private ReplayWindow replayWindow;
    [SerializeField]
    private InGameUI inGame;

    private void Start()
    {
        insatnce = this;

        SetColor(start, alpha);
        SetColor(extra, alpha);
        SetColor(replay, alpha);
        SetColor(score, alpha);
        SetColor(music, alpha);
        SetColor(option, alpha);
        SetColor(exit, alpha);

        //��ư�� ������
        dictionary[start] = GameStart;
        dictionary[extra] = ExtraStart;
        dictionary[replay] = ReplayStart;
        dictionary[score] = Score;
        dictionary[music] = Music;
        dictionary[option] = Option;
        dictionary[exit] = Exit;
        //ù �������� ��ư�� start
        select = start;
        //index�δ� 0
        Choice(0);
    }

    private void Update()
    {
        //if(STGManager.Instance.Playing)
        //{
        //    if(Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        STGManager.Instance.Playing = false;
        //        Time.timeScale = 0;
        //        inGame.gameObject.SetActive(true);
        //    }
        //}
        //else
        //{
        //    if (Input.GetKeyDown(KeyCode.Escape))
        //    {
        //        STGManager.Instance.Playing = true;
        //        Time.timeScale = 1;
        //        inGame.gameObject.SetActive(false);
        //    }
        //}

        if (!mainmenu.activeSelf)
            return;

        //Ű�Է��� �޾� �� �Ʒ��� �޴��� ����
        if (Input.GetKeyDown(KeyCode.DownArrow))
            index = math.clamp(index + 1, 0, 6);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            index = math.clamp(index - 1, 0, 6);
        Choice(index);

        //zŰ�� ����
        if (Input.GetKeyDown(KeyCode.Z))
            dictionary[select]();
    }

    //���ڷ� ���� �޴��� �������� ����
    private void Choice(int index)
    {
        SetColor(select, alpha);
        switch(index)
        {
            case 0:
                select = start;
                break;
            case 1:
                select = extra;
                break;
            case 2:
                select = replay;
                break;
            case 3:
                select = score;
                break;
            case 4:
                select = music;
                break;
            case 5:
                select = option;
                break;
            case 6:
                select = exit;
                break;
        }

        SetColor(select, 1);
    }

    //���� ���� ���
    private void GameStart()
    {
        OnGameObject();
        Player.Instance.PlayMode = new RecordMode();
        Player.Instance.Life = 2;
        Player.Instance.Bomb = 2;
    }

    private void ExtraStart()
    {
        //������
    }

    //�ϴ��� �׳� �ε������� ���ϵ��� �ε��� ���� �����ؼ� ����ϵ��� �ؾ���
    //������ �̸��� ���� ����� score ���ҵ� ����
    private void ReplayStart()
    {
        //OnGameObject();
        //Player.Instance.PlayMode = new ReplayMode();
        //Player.Instance.Life = 2;
        //Player.Instance.Bomb = 2;
        replayWindow.gameObject.SetActive(true);
        mainmenu.gameObject.SetActive(false);
    }

    private void Score()
    {
        //���÷��̿� ����
    }

    private void Music()
    {

    }

    private void Option()
    {

    }

    private void Exit()
    {

    }

    public void MainMenu()
    {
        STGManager.Instance.Reset();
        StartCoroutine(MainMenuCoroutine());
    }

    //�ٷ� ������ �����ع����� ���� ������ �� ������ �ʰ� �Ѿ� �ҵ�
    private IEnumerator MainMenuCoroutine()
    {
        yield return null;
        OffGameObject();
    }











    private void SetColor(TextMeshProUGUI text, float alpha)
    {
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }

    public void OnGameObject()
    {
        //�÷��̾� ��ü ����
        Player.Instance.Ship = ship;
        ship.transform.position = InfoStatic.spawnPoint;
        ship.gameObject.SetActive(true);
        Player.Instance.AddPower(0.1f);

        //ui ����
        //start.gameObject.SetActive(false);
        //extra.gameObject.SetActive(false);
        //replay.gameObject.SetActive(false);
        //score.gameObject.SetActive(false);
        //music.gameObject.SetActive(false);
        //option.gameObject.SetActive(false);
        //exit.gameObject.SetActive(false);
        mainmenu.SetActive(false);

        powerUI.SetActive(true);
        lifeUI.SetActive(true);
        bombUI.SetActive(true);
        scoreUI.SetActive(true);

        foreach (var item in panelUI)
        {
            item.SetActive(true);
        }

        //�÷��� ����
        STGManager.Instance.Playing = true;
    }

    private void OffGameObject()
    {
        ScoreManager.Instance.Reset();
        //�÷��̾� ��ü ����
        Player.Instance.PowerInit();
        Player.Instance.Ship = null;
        ship.gameObject.SetActive(false);


        //ui ����
        //start.gameObject.SetActive(true);
        //extra.gameObject.SetActive(true);
        //replay.gameObject.SetActive(true);
        //score.gameObject.SetActive(true);
        //music.gameObject.SetActive(true);
        //option.gameObject.SetActive(true);
        //exit.gameObject.SetActive(true);
        mainmenu.SetActive(true);

        powerUI.SetActive(false);
        lifeUI.SetActive(false);
        bombUI.SetActive(false);
        scoreUI.SetActive(false);

        foreach (var item in panelUI)
        {
            item.SetActive(false);
        }
    }
}
