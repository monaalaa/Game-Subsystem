using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinsState : MyGameState
{
    public override int StateProperity
    {
        get => _stateProperity;
        set
        {
            var coins = _stateProperity;
            _stateProperity = value;

            if (value != coins)
            {
                InvokeStateChanged(this, _stateProperity);
            }
        }
    }
}
