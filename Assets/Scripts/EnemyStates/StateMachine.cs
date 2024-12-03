using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine<T>
{
    public IState<T> CurrentState { get; private set; }
    public T Owner { get; private set; }

    public StateMachine(T owner)
    {
        Owner = owner;
    }

    public void ChangeState(IState<T> newState)
    {
        CurrentState?.Exit(Owner);
        CurrentState = newState;
        CurrentState?.Enter(Owner);
    }

    public void Update()
    {
        CurrentState?.Execute(Owner);
    }
}

