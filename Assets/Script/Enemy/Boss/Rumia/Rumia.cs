using UnityEngine;

public class Rumia : Boss
{
    [SerializeField]
    private Rumia_Phase_1 phase_1;
    [SerializeField]
    private Rumia_Phase_2 phase_2;

    new protected void Start()
    {
        base.Start();
        appearancePhase.Init(this, phase_1, moveObject.moveTypes[0].ToArray());
        phase_1.Init(this, phase_2, new MoveType[2] { moveObject.moveTypes[1], moveObject.moveTypes[2] });
        phase_2.Init(this, null, new MoveType[2] { moveObject.moveTypes[1], moveObject.moveTypes[2] });
        moveObject.moveTypes = null;

        Now = appearancePhase;
    }
}
