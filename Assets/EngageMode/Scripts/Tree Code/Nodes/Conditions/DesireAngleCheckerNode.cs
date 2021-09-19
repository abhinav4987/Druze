using UnityEngine;

public class DesiredAngleCheckerNode : Node
{

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        float angleAllowedRangeMagnitude = 3f;

        float gravityAcc = Physics.gravity.magnitude, initialSpeed = shipParameters.parameters.GetSelfCannonInitialSpeed();
        float shootDistance = shipParameters.parameters.GetDistanceBetweenSelfAndEnemy();

        float desiredAngle = 0.5f * Mathf.Asin(gravityAcc * shootDistance / (initialSpeed * initialSpeed));
        float currentAngle = shipParameters.parameters.GetSelfCannonAngle();

        return Mathf.Abs(desiredAngle - currentAngle) < angleAllowedRangeMagnitude ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}