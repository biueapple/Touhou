using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using UnityEngine;

//�÷��̾��� �Է°�
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

//���÷���
public class Replay : MonoBehaviour
{
    //�÷��̾ �Է��� ��� �Է°��� ���
    List<FrameInput> inputRecord = new();
    //���÷��� �����Ѱ� �ҷ���
    string[] files = null;

    private void Start()
    {
        //��� ���÷��� �ҷ�����
        LoadAll();
        //���� �̵��� ���� ������ �𸣰���
        DontDestroyOnLoad(this);
    }

    //Ű ����ϴ� �޼ҵ�
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

    //���� ������
    public int currentFrame = 0;
    //���÷��� ���
    public void PlaybackInput()
    {
        //������ ��� �Է�
        if (currentFrame >= inputRecord.Count)
        {
            //�ٽ� ���÷��� ������� �Ѿ�� (���� �ʿ���)
            Player.Instance.record = true;
            return;
        }
        //�� �����ӿ� ���� �Է��� �ߴ��� �޾Ƽ�
        FrameInput input = inputRecord[currentFrame];

        // �Է°��� ���� ���� ��� ����
        Player.Instance.ApplyInput(input);

        //���� ����������
        currentFrame++;
    }

    //���÷��̸� ����
    public void SaveReplay()
    {
        string json = JsonUtility.ToJson(new InputRecordWrapper { frames = inputRecord });
        string fileName = "replay_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".json";
        string path = Path.Combine(Application.persistentDataPath, fileName);
        File.WriteAllText(path, json);
    }

    //��� ���÷��� �ҷ�����
    public void LoadAll()
    {
        files = Directory.GetFiles(Application.persistentDataPath, "replay_*.json");
    }

    //���� �̸����� ���÷��� �Է°� �ҷ�����
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

    //��� ���÷��� ������ �̸��� ����
    public List<string> GetName()
    {
        return files.Select(path => Path.GetFileName(path)).ToList();
    }

    //ui�ε�
    //void OnReplaySelected(string fileName)
    //{
    //    currentReplay = LoadReplayFromFile(fileName);
    //    currentFrame = 0;
    //    isPlayingBack = true;
    //}
}

//json���� �����ϱ� ���� �ѹ� ����
[Serializable]
public class InputRecordWrapper
{
    public List<FrameInput> frames;
}
