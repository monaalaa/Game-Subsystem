using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarsState : MyGameState
{
    public override int StateProperity
    {
        get => _stateProperity;
        set
        {
            var stars = _stateProperity;
            _stateProperity = value;

            if (value != stars)
            {
                InvokeStateChanged(this, _stateProperity);
            }
        }
    }
}
