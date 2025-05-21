using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

public class STGMain : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI start;
    [SerializeField]
    private TextMeshProUGUI extra;
    [SerializeField]
    private TextMeshProUGUI replay;
    [SerializeField]
    private TextMeshProUGUI score;
    [SerializeField]
    private TextMeshProUGUI music;
    [SerializeField]
    private TextMeshProUGUI option;
    [SerializeField]
    private TextMeshProUGUI exit;
    [SerializeField]
    private Player_Ship ship;

    private readonly Dictionary<TextMeshProUGUI, Action> dictionary = new();
    private TextMeshProUGUI select = null;
    private int index = 0;

    private void Start()
    {
        dictionary[start] = GameStart;
        dictionary[extra] = ExtraStart;
        dictionary[replay] = ReplayStart;
        dictionary[score] = Score;
        dictionary[music] = Music;
        dictionary[option] = Option;
        dictionary[exit] = Exit;
        select = start;
        Choice(0);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.DownArrow))
            index = math.clamp(index + 1, 0, 6);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            index = math.clamp(index - 1, 0, 6);
        Choice(index);

        if (Input.GetKeyDown(KeyCode.Z))
            dictionary[select]();
    }

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

    private void GameStart()
    {
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
