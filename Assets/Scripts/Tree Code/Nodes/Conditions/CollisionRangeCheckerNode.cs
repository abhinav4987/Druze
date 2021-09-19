using UnityEngine;

public class CollisionRangeCheckerNode : Node {

Vector3 currentPosition;

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.parameters.GetDistanceBetweenSelfAndEnemy() < shipParameters.parameters.collisionRange ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}