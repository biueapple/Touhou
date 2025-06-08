using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
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

    //��� ��ư��� ����� ��Ī���ѳ��� ��ư�� onclick�� ������� ���� ������ �׳� �̰� �� ���ؼ�
    private readonly Dictionary<TextMeshProUGUI, Action> dictionary = new();
    //���� �������� �޴�
    private TextMeshProUGUI select = null;
    //�ε����δ� �̰�
    private int index = 0;
    //��Ȱ��ȭ alpha��
    private readonly float alpha = 0.4901961f;


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
        //�׽�Ʈ �뵵�� ����� ���� �ڵ��
        Player.Instance.Ship = ship;
        ship.transform.position = InfoStatic.spawnPoint;
        ship.gameObject.SetActive(true);
        gameObject.SetActive(false);
        STGManager.Instance.Playing = true;
        Player.Instance.AddPower(0.1f);
        Player.Instance.PlayMode = new RecordMode();
    }

    private void ExtraStart()
    {

    }

    private void ReplayStart()
    {
        //�ϴ��� �׳� �ε������� ���ϵ��� �ε��� ���� �����ؼ� ����ϵ��� �ؾ���
        Player.Instance.Ship = ship;
        ship.transform.position = InfoStatic.spawnPoint;
        ship.gameObject.SetActive(true);
        gameObject.SetActive(false);
        STGManager.Instance.Playing = true;
        Player.Instance.AddPower(0.1f);
        Player.Instance.PlayMode = new ReplayMode();
    }

    private void Score()
    {

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
        Player.Instance.PlayMode = null;
        gameObject.SetActive(true);
        ship.gameObject.SetActive(false);
        Player.Instance.PowerInit();
        Player.Instance.Ship = null;
    }

    private void SetColor(TextMeshProUGUI text, float alpha)
    {
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }
}
