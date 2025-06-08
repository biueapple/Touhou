using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

//플레이어의 입력값
public struct FrameInput
{
    public bool Up;
    public bool Down;
    public bool Left;
    public bool Right;
    public bool Fire;
    public bool ShiftDown;
    public bool ShiftUp;
}

//리플레이
public class Replay : MonoBehaviour
{
    private static Replay insatnce = null;
    public static Replay Instance
    {
        get
        {
            insatnce = insatnce != null ? insatnce : FindFirstObjectByType<Replay>();
            insatnce = insatnce != null ? insatnce : new GameObject("Replay").AddComponent<Replay>();
            return insatnce;
        }
    }


    //플레이어가 입력한 모든 입력값을 기록
    List<FrameInput> inputRecord = new();
    //리플레이 저장한걸 불러옴
    string[] files = null;

    private void Start()
    {
        insatnce = this;
        //모든 리플레이 불러오기
        LoadAll();
        //씬을 이동할 일이 있을진 모르겠음
        //DontDestroyOnLoad(this);
    }

    //키 기록하는 메소드
    public void RecordInput()
    {
        FrameInput input = new()
        {
            Up = Input.GetKey(KeyCode.UpArrow),
            Down = Input.GetKey(KeyCode.DownArrow),
            Left = Input.GetKey(KeyCode.LeftArrow),
            Right = Input.GetKey(KeyCode.RightArrow),
            Fire = Input.GetKey(KeyCode.Z),
            ShiftDown = Input.GetKeyDown(KeyCode.LeftShift),
            ShiftUp = Input.GetKeyUp(KeyCode.LeftShift)
        };

        inputRecord.Add(input);
    }

    //현재 프레임
    public int currentFrame = 0;
    //리플레이 재생
    public FrameInput PlaybackInput()
    {
        //범위를 벗어난 입력
        if (currentFrame >= inputRecord.Count)
        {
            //다시 리플레이 기록으로 넘어가기 (수정 필요함)
            return new ();
        }
        currentFrame++;
        //그 프레임에 무슨 입력을 했는지 받아서
        return inputRecord[currentFrame];

        // 입력값을 실제 조작 대신 적용
        //Player.Instance.ApplyInput(input);

        //다음 프레임으로
    }

    //리플레이를 저장
    public void SaveReplay()
    {
        string json = JsonUtility.ToJson(new InputRecordWrapper { frames = inputRecord });
        string fileName = "replay_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
    }

    //모든 리플레이 불러오기
    public void LoadAll()
    {
        files = Directory.GetFiles(Application.persistentDataPath, "replay_*.json");
    }

    //파일 이름으로 리플레이 입력값 불러오기
    public List<FrameInput> LoadReplay(string filename)
    {
        string path = Path.Combine(Application.persistentDataPath, filename);

        if (!File.Exists(path))
        {
            Debug.LogError("Replay file not found at: " + path);
            return null;
        }

        string json = File.ReadAllText(path);
        InputRecordWrapper data = JsonUtility.FromJson<InputRecordWrapper>(json);
        return data.frames;
    }

    //모든 리플레이 파일의 이름을 리턴
    public List<string> GetName()
    {
        return files.Select(path => Path.GetFileName(path)).ToList();
    }

    //void OnReplaySelected(string fileName)
    //{
    //    currentReplay = LoadReplayFromFile(fileName);
    //    currentFrame = 0;
    //    isPlayingBack = true;
    //}
}

//json으로 저장하기 위해 한번 래핑
[Serializable]
public class InputRecordWrapper
{
    public List<FrameInput> frames;
}
