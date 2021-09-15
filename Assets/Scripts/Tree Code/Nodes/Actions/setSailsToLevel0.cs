using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class SetSailsToLevel0 : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.SetSailLevel(0);
        return NodeState.SUCCESS;
    }
}