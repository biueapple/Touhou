using UnityEngine;

public interface IPhase
{
    void Enter();      
    void Execute();     
    void Exit();        
}
