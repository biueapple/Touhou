using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using UnityEngine;

//ui를 만들었지만 삭제되어서 아직 사용중이지는 않는 스크립트 귀찮아서 모든 ui를 여기서 관리하려고 했지만 역시 나누는게 맞는듯
public class STGMain : MonoBehaviour
{
    //게임 시작 버튼 역할
    [SerializeField]
    private TextMeshProUGUI start;
    //엑스트라 스테이지 시작 버튼 (처음에는 보이지 않아야 함 {엑스트라 스테이지를 만들지는 모르겠음})
    [SerializeField]
    private TextMeshProUGUI extra;
    //리플레이 다시보기 버튼
    [SerializeField]
    private TextMeshProUGUI replay;
    //점수 보기 버튼
    [SerializeField]
    private TextMeshProUGUI score;
    //음악을 다시 들을 수 있는 공간
    [SerializeField]
    private TextMeshProUGUI music;
    //옵션을 설정하는 공간
    [SerializeField]
    private TextMeshProUGUI option;
    //게임 종료
    [SerializeField]
    private TextMeshProUGUI exit;
    //일단은 테스트 용도
    [SerializeField]
    private Player_Ship ship;

    //모든 버튼들과 기능을 매칭시켜놓음 버튼과 onclick을 사용하지 않은 이유는 그냥 이게 더 편해서
    private readonly Dictionary<TextMeshProUGUI, Action> dictionary = new();
    //현재 선택중인 메뉴
    private TextMeshProUGUI select = null;
    //인덱스로는 이거
    private int index = 0;

    
    private void Start()
    {
        //버튼들 적용중
        dictionary[start] = GameStart;
        dictionary[extra] = ExtraStart;
        dictionary[replay] = ReplayStart;
        dictionary[score] = Score;
        dictionary[music] = Music;
        dictionary[option] = Option;
        dictionary[exit] = Exit;
        //첫 선택중인 버튼은 start
        select = start;
        //index로는 0
        Choice(0);
    }

    private void Update()
    {
        //키입력을 받아 위 아래로 메뉴를 선택
        if (Input.GetKeyDown(KeyCode.DownArrow))
            index = math.clamp(index + 1, 0, 6);
        else if (Input.GetKeyDown(KeyCode.UpArrow))
            index = math.clamp(index - 1, 0, 6);
        Choice(index);

        //z키로 실행
        if (Input.GetKeyDown(KeyCode.Z))
            dictionary[select]();
    }

    //숫자로 무슨 메뉴룰 선택할지 적용
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

    //게임 시작 기능
    private void GameStart()
    {
        //테스트 용도로 만들어 놓은 코드들
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
