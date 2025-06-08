using System;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

//ui를 만들었지만 삭제되어서 아직 사용중이지는 않는 스크립트 귀찮아서 모든 ui를 여기서 관리하려고 했지만 역시 나누는게 맞는듯
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
    //비활성화 alpha값
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

    //게임 시작 기능
    private void GameStart()
    {
        //테스트 용도로 만들어 놓은 코드들
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
        //일단은 그냥 로드하지만 파일들을 로드한 다음 선택해서 재생하도록 해야함
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
