using UnityEngine;

public class HealthCheckerNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        float healthDiff = shipParameters.parameters.GetSelfHealth() - shipParameters.parameters.GetEnemyHealth();
        return healthDiff > shipParameters.parameters.threshold ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}