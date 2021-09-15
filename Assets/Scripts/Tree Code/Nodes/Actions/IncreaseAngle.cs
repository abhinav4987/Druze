using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class IncreaseAngle : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.IncreaseCannonAngle();
        return NodeState.SUCCESS;
    }
}