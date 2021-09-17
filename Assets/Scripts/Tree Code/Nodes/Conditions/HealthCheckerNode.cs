using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class HealthCheckerNode : Node {
    private Sail sail;
    public HealthCheckerNode( Sail sail){
        this.sail = sail;

    }

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return sail.GetSailHealth() >= shipParameters.threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}