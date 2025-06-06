using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

//ui�� ��������� �����Ǿ ���� ����������� �ʴ� ��ũ��Ʈ �����Ƽ� ��� ui�� ���⼭ �����Ϸ��� ������ ���� �����°� �´µ�
public class STGMain : MonoBehaviour
{
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

    
    private void Start()
    {
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
        Color color = select.color;
        color.a = 0.4901961f;
        select.color = color;
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
        color = select.color;
        color.a = 1;
        select.color = color;
    }

    //���� ���� ���
    private void GameStart()
    {
        //�׽�Ʈ �뵵�� ����� ���� �ڵ��
        Player.Instance.Ship = ship;
        ship.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }

    private void ExtraStart()
    {

    }

    private void ReplayStart()
    {

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
}
