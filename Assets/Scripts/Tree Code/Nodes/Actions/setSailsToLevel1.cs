using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class SetSailsToLevel1 : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.SetSailLevel(1);
        return NodeState.SUCCESS;
    }
}