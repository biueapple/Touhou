using UnityEngine;

public class RecordMode : IPlayMode
{
    

    public void Update()
    {
        Player.Instance.ApplyInput(Enter());
    }

    private FrameInput Enter()
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
        return input;
    }
}
