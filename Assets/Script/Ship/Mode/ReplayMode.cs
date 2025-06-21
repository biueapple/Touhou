using UnityEngine;

public class ReplayMode : IPlayMode
{

    public void Update()
    {
        Player.Instance.ApplyInput(Replay.Instance.PlaybackInput());

        //�ƹ�Ű�� ������ �ٽ� ���� �޴���
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
