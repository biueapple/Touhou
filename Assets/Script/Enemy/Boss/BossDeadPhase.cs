using UnityEngine;

[System.Serializable]
public class BossDeadPhase : Phase
{
    public override void Enter()
    {
        boss.Dead();
        BossHPUI.Instance.SetBoss(null);
        BulletManager.Instance.ClearBullet();
        //GameClearUI.Instance.Open();
        Player.Instance.PlayMode.GameEnd();
    }

    public override void Excute()
    {

    }

    public override void Exit()
    {

    }
}
