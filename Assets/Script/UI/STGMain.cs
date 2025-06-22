using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.Mathematics;
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

    [SerializeField]
    private GameObject mainmenu;
    [SerializeField]
    private GameObject[] panelUI;
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

    [SerializeField]
    private GameObject powerUI;
    [SerializeField]
    private GameObject lifeUI;
    [SerializeField]
    private GameObject bombUI;
    [SerializeField]
    private GameObject scoreUI;

    //모든 버튼들과 기능을 매칭시켜놓음 버튼과 onclick을 사용하지 않은 이유는 그냥 이게 더 편해서
    private readonly Dictionary<TextMeshProUGUI, Action> dictionary = new();
    //현재 선택중인 메뉴
    private TextMeshProUGUI select = null;
    //인덱스로는 이거
    private int index = 0;
    //비활성화 alpha값
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
        OnGameObject();
        Player.Instance.PlayMode = new RecordMode();
        Player.Instance.Life = 2;
        Player.Instance.Bomb = 2;
    }

    private void ExtraStart()
    {
        //없애자
    }

    //일단은 그냥 로드하지만 파일들을 로드한 다음 선택해서 재생하도록 해야함
    //점수와 이름도 옆에 띄워서 score 역할도 하자
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
        //리플레이에 넣자
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

    //바로 게임이 시작해버리는 문제 때문에 한 프레임 늦게 켜야 할듯
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
        //플레이어 기체 설정
        Player.Instance.Ship = ship;
        ship.transform.position = InfoStatic.spawnPoint;
        ship.gameObject.SetActive(true);
        Player.Instance.AddPower(0.1f);

        //ui 설정
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

        //플레이 시작
        STGManager.Instance.Playing = true;
    }

    private void OffGameObject()
    {
        ScoreManager.Instance.Reset();
        //플레이어 기체 설정
        Player.Instance.PowerInit();
        Player.Instance.Ship = null;
        ship.gameObject.SetActive(false);


        //ui 설정
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
