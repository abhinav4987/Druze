using UnityEngine;

public class DesiredCannoRreadyCheckerNode : Node
{
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        Vector3 relativePosition = shipParameters.parameters.GetEnemyRelativeFromSelf();
        if (relativePosition.z == 0)
            return NodeState.FAILURE;
        else if (relativePosition.z > 0)
            return shipParameters.parameters.GetSelfCannonReadyState(0) ? NodeState.SUCCESS : NodeState.FAILURE;
        else
            return shipParameters.parameters.GetSelfCannonReadyState(1) ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
