using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class FireCannon : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.FireCannon();
        return NodeState.SUCCESS;
    }
}