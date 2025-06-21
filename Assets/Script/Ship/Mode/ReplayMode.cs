using UnityEngine;

public class ReplayMode : IPlayMode
{

    public void Update()
    {
        Player.Instance.ApplyInput(Replay.Instance.PlaybackInput());

        //아무키나 누르면 다시 메인 메뉴로
        if(Input.GetKeyDown(KeyCode.Space))
        {
            STGMain.Instance.MainMenu();
        }
    }

    public void GameEnd()
    {
        STGMain.Instance.MainMenu();
    }
}
