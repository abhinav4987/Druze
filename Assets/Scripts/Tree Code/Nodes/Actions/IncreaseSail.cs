using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class IncreaseSail : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.IncreaseSail();
        return NodeState.SUCCESS;
    }
}