using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class DecreaseAngle : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.DecreaseCannonAngle();
        return NodeState.SUCCESS;
    }
}