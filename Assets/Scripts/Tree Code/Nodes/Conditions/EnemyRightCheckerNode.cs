using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class EnemyRightCheckerNode : Node {

Vector3 currentPosition;

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.enemyTransform.Position.x > currentPosition.Position.x ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}