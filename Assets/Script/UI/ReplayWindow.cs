using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System.IO;
using TMPro;

public class ReplayWindow : MonoBehaviour
{
    public TextMeshProUGUI itemPrefab; // 텍스트 or 버튼 프리팹
    public Transform contentParent; // Vertical LayoutGroup이 붙어 있는 부모
    private List<TextMeshProUGUI> items = new();
    public TextMeshProUGUI exit;
    private int selectedIndex = 0;
    private List<InputRecordWrapper> filePaths = new();
    private bool isExitSelected = false;

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
            item.text = file.name;
            items.Add(item);
        }
    }

    private void UpdateHighlight()
    {
        for (int i = 0; i < items.Count; i++)
        {
            items[i].color = (i == selectedIndex) ? Color.yellow : Color.white;
        }
        exit.color = isExitSelected ? Color.yellow : Color.white;
    }

    private void SelectReplay()
    {
        string selectedFile = filePaths[selectedIndex].name;
        Debug.Log("선택한 리플레이: " + selectedFile);

        // 여기서 리플레이 로딩 호출 가능
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
