using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class DecreaseSail : Node {
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.DecreaseSail();
        return NodeState.SUCCESS;
    }
}


