using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class CollisionRangeCheckerNode : Node {

Vector3 currentPosition;

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return Vector3.Distance(shipParameters.enemyTransform.Position,currentPosition.Position)< shipParameters.collisionRange ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}