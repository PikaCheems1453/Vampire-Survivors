using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStateMachine
{
    public EnemyState CurrentState { get; private set; }

    public void Initialize(EnemyState _state)
    {
        CurrentState = _state;
        CurrentState.Enter();
    }

    public void ChangeState(EnemyState nextState)
    {
        CurrentState.Exite();
        CurrentState = nextState;
        CurrentState.Enter();
    }
}
