using UnityEngine;
public class EnemyRightCheckerNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.parameters.GetEnemyRelativeFromSelf().z < 0 ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}