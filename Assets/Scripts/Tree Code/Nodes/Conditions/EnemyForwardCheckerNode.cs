using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class EnemyForwardCheckerNode : Node {

Vector3 currentPosition;

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.enemyTransform.Position.y > currentPosition.Position.y ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}