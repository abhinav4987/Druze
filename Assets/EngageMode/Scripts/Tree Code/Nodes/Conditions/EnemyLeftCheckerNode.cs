using UnityEngine;

public class EnemyLeftCheckerNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.parameters.GetEnemyRelativeFromSelf().z > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}