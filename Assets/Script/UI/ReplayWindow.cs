using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class ReplayWindow : MonoBehaviour
{
    public TextMeshProUGUI itemPrefab; // �ؽ�Ʈ or ��ư ������
    public Transform contentParent; // Vertical LayoutGroup�� �پ� �ִ� �θ�
    private List<TextMeshProUGUI> items = new();
    public TextMeshProUGUI exit;
    private int selectedIndex = 0;
    private List<InputRecordWrapper> filePaths = new();
    private bool isExitSelected = false;

    public ScrollRect scrollRect; // ���� �ʿ�
    public int visibleItemCount = 5; // ȭ�鿡 ǥ�õǴ� �׸� �� (��: 5)


    private void Start()
    {
        LoadReplayList();
        UpdateHighlight();
    }

    private void Update()
    {
        if (!isExitSelected)
        {
            if (Input.GetKeyDown(KeyCode.DownArrow))
            {
                selectedIndex = Mathf.Min(selectedIndex + 1, items.Count - 1);
                UpdateHighlight();
            }
            else if (Input.GetKeyDown(KeyCode.UpArrow))
            {
                selectedIndex = Mathf.Max(selectedIndex - 1, 0);
                UpdateHighlight();
            }
            else if (Input.GetKeyDown(KeyCode.RightArrow))
            {
                isExitSelected = true;
                UpdateHighlight();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                SelectReplay();
            }
        }
        else
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow))
            {
                isExitSelected = false;
                UpdateHighlight();
            }
            else if (Input.GetKeyDown(KeyCode.Z))
            {
                Exit();
            }
        }   
    }

    private void LoadReplayList()
    {
        filePaths = Replay.Instance.FileToInputRecordWrapper();

        foreach (var file in filePaths)
        {
            TextMeshProUGUI item = Instantiate(itemPrefab, contentParent);
            item.text = file.name + "\t" + file.score;
            items.Add(item);
        }
    }

    private void UpdateHighlight()
    { 
        if(!isExitSelected)
        {
            exit.color = Color.white;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].color = (i == selectedIndex) ? Color.yellow : Color.white;
            }
        } 
        else
        {
            exit.color = Color.yellow;
            for (int i = 0; i < items.Count; i++)
            {
                items[i].color = Color.white;
            }
        }
            
        UpdateScrollPosition();
    }

    private void UpdateScrollPosition()
    {
        if (items.Count <= visibleItemCount || isExitSelected) return;

        int maxScrollStartIndex = items.Count - visibleItemCount;

        // ���� �׸��� ȭ�� �߾ӿ� ������ topIndex ����
        int centerOffset = visibleItemCount / 2;
        int targetTopIndex = Mathf.Clamp(selectedIndex - centerOffset, 0, maxScrollStartIndex);

        float normalizedPos = 1f - ((float)targetTopIndex / maxScrollStartIndex);
        scrollRect.verticalNormalizedPosition = normalizedPos;
    }





    private void SelectReplay()
    {
        string selectedFile = filePaths[selectedIndex].name;

        // ���⼭ ���÷��� �ε� ȣ�� ����
        gameObject.SetActive(false);
        Replay.Instance.inputRecord = filePaths[selectedIndex].frames;
        STGMain.Instance.OnGameObject();
        Player.Instance.PlayMode = new ReplayMode();
        Player.Instance.Life = 2;
        Player.Instance.Bomb = 2;
    }

    private void Exit()
    {
        STGMain.Instance.MainMenu();
        selectedIndex = 0;
        UpdateHighlight();
        gameObject.SetActive(false);
    }
}
