using UnityEngine;

public class ShipAlignmentCheckerNode : Node
{

    float horizontalAllowedAngleRange;
    float targetAngle;
    public ShipAlignmentCheckerNode(float horizontalAllowedAngleRange, float targetAngle)
    {
        this.horizontalAllowedAngleRange = horizontalAllowedAngleRange;
        this.targetAngle = targetAngle;
    }
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        float angleWithEnemy = shipParameters.parameters.GetAngleFromSelfToEnemy();

        return Mathf.Abs(angleWithEnemy - targetAngle) < horizontalAllowedAngleRange ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}