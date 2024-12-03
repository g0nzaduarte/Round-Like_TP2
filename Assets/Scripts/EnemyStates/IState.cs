using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IState<T>
{
    void Enter(T owner);
    void Execute(T owner);
    void Exit(T owner);
}

