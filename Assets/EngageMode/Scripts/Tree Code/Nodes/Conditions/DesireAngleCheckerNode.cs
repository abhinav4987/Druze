using UnityEngine;

public class DesiredAngleCheckerNode : Node
{
    float verticalAllowedAngleRange;
    public DesiredAngleCheckerNode(float verticalAllowedAngleRange)
    {
        this.verticalAllowedAngleRange = verticalAllowedAngleRange;
    }

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {

        float gravityAcc = Physics.gravity.magnitude, initialSpeed = shipParameters.parameters.GetSelfCannonInitialSpeed();
        float shootDistance = shipParameters.parameters.GetDistanceBetweenSelfAndEnemy();

        float desiredAngle = 0.5f * Mathf.Asin(gravityAcc * shootDistance / (initialSpeed * initialSpeed)) * Mathf.Rad2Deg;
        float currentAngle = shipParameters.parameters.GetSelfCannonAngle();

        return Mathf.Abs(desiredAngle - currentAngle) < verticalAllowedAngleRange ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}