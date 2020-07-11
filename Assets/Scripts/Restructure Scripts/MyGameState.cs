using System;
using UnityEngine;

public class MyGameState : MonoBehaviour
{
    protected int _stateProperity;
    public event Action<MyGameState,int> StateChanged = (ProperityType,Value) => { };

    protected void InvokeStateChanged(MyGameState type, int value)
    {
        StateChanged(type, value);
    }

    public virtual int StateProperity
    {
        get => _stateProperity;
        set { }
    }
}
