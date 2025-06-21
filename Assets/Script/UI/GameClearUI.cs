using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Unity.Mathematics;

public class GameClearUI : MonoBehaviour
{
    private static GameClearUI insatnce = null;
    public static GameClearUI Instance
    {
        get
        {
            insatnce = insatnce != null ? insatnce : FindFirstObjectByType<GameClearUI>();
            insatnce = insatnce != null ? insatnce : new GameObject("GameClearUI").AddComponent<GameClearUI>();
            return insatnce;
        }
    }

    [SerializeField]
    private TMP_InputField inputField;
    [SerializeField]
    private TextMeshProUGUI save;
    [SerializeField]
    private TextMeshProUGUI main;

    private readonly Dictionary<TextMeshProUGUI, Action> dictionary = new();
    //���� �������� �޴�
    private TextMeshProUGUI select = null;
    int index = 0;

    public void Open()
    {
        STGManager.Instance.Playing = false;
        inputField.gameObject.SetActive(true);
        save.gameObject.SetActive(true);
        main.gameObject.SetActive(true);
        Player.Instance.PlayMode = null;
        inputField.ActivateInputField(); // Ŀ�� Ȱ��ȭ (��Ŀ��)
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        insatnce = this;
        dictionary.Add(save, Save);
        dictionary.Add(main, Main);
        Choice(0);
    }

    private void Update()
    {
        if (!inputField.gameObject.activeSelf)
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

    private void Choice(int change)
    {
        TextMeshProUGUI text;

        if(select != null)
            SetColor(select, 0.5f);

        index = change;
        if (index == 0)
            text = save;
        else
            text = main;
        SetColor(text, 1);
        select = text;
    }

    private void SetColor(TextMeshProUGUI text, float alpha)
    {
        Color color = text.color;
        color.a = alpha;
        text.color = color;
    }

    private void Save()
    {
        if(inputField.text.Length != 0)
        {
            Replay.Instance.SaveReplay(inputField.text);
            Replay.Instance.LoadAll();
        }
    }

    private void Main()
    {
        inputField.gameObject.SetActive(false);
        save.gameObject.SetActive(false);
        main.gameObject.SetActive(false);
        STGMain.Instance.MainMenu();
    }
}
