using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class TurnLeft : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.TurnLeft();
        return NodeState.SUCCESS;
    }
}