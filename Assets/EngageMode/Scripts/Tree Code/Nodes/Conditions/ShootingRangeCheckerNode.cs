using UnityEngine;

public class ShootingRangeCheckerNode : Node {
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.parameters.GetDistanceBetweenSelfAndEnemy() < shipParameters.parameters.shootingRange ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}