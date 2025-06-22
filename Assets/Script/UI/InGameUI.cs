using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class InGameUI : MonoBehaviour
{
    private List<TextMeshProUGUI> list = new();
    private int select;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            select = Mathf.Min(select + 1, list.Count - 1);
            UpdateHighlight();
        }
        else if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            select = Mathf.Max(select - 1, 0);
            UpdateHighlight();
        }
        else if (Input.GetKeyDown(KeyCode.Z))
        {
            Apply();
        }
    }

    public void UpdateHighlight()
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].color = (i == select) ? Color.yellow : Color.white;
        }
    }

    private void Apply()
    {
        if(select == 0)
        {
            //되돌아가기
        }
        else
        {
            //나가기
        }
    }
}
