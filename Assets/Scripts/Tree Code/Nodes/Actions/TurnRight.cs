using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class TurnRight : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.TurnRight();
        return NodeState.SUCCESS;
    }
}