using UnityEngine;

public class EnemyForwardCheckerNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.parameters.GetEnemyRelativeFromSelf().x > 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}