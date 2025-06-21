using UnityEngine;

public class RecordMode : IPlayMode
{
    public void Update()
    {
        Player.Instance.ApplyInput(Replay.Instance.RecordInput());
    }
    public void GameEnd()
    {
        GameClearUI.Instance.Open();
    }
}
