using UnityEngine;

public class ManeuverableAngleCheckerNode : Node
{

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        float angle = shipParameters.parameters.GetAngleFromSelfToEnemy();
        return angle < shipParameters.parameters.maneuverableAngle ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
