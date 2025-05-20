using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

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

public class Replay : MonoBehaviour
{
    List<FrameInput> inputRecord = new();
    string[] files = null;

    private void Start()
    {
        LoadAll();
        DontDestroyOnLoad(this);
    }

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

    public int currentFrame = 0;

    public void PlaybackInput()
    {
        if (currentFrame >= inputRecord.Count)
        {
            Player.Instance.record = true;
            return;
        }
        FrameInput input = inputRecord[currentFrame];

        // 입력값을 실제 조작 대신 적용
        Player.Instance.ApplyInput(input);

        currentFrame++;
    }

    public void SaveReplay()
    {
        string json = JsonUtility.ToJson(new InputRecordWrapper { frames = inputRecord });
        string fileName = "replay_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
    }

    public void LoadAll()
    {
        files = Directory.GetFiles(Application.persistentDataPath, "replay_*.json");
    }

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

    public List<FrameInput> LoadReplayFromFile(string fileName)
    {
        string path = Path.Combine(Application.persistentDataPath, fileName);
        if (!File.Exists(path))
        {
            Debug.LogError("Replay file not found: " + path);
            return null;
        }

        string json = File.ReadAllText(path);
        InputRecordWrapper data = JsonUtility.FromJson<InputRecordWrapper>(json);
        return data.frames;
    }

    public List<string> GetName()
    {
        return files.Select(path => Path.GetFileName(path)).ToList();
    }

    //ui로드
    //void OnReplaySelected(string fileName)
    //{
    //    currentReplay = LoadReplayFromFile(fileName);
    //    currentFrame = 0;
    //    isPlayingBack = true;
    //}
}

[Serializable]
public class InputRecordWrapper
{
    public List<FrameInput> frames;
}
