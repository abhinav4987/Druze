using UnityEngine;

public class CannonShootDistanceLessNode : Node
{
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        float angle = shipParameters.parameters.GetSelfCannonAngle() * Mathf.Deg2Rad;
        float initialSpeed = shipParameters.parameters.GetSelfCannonInitialSpeed(), gravityAcc = Physics.gravity.magnitude;

        float calculatedShootDistance = (initialSpeed * initialSpeed * Mathf.Sin(2 * angle)) / gravityAcc;

        Debug.DrawRay(shipParameters.parameters.GetSelfTransform().position, shipParameters.parameters.GetSelfTransform().forward * calculatedShootDistance, Color.green, Time.deltaTime);

        return calculatedShootDistance < shipParameters.parameters.GetDistanceBetweenSelfAndEnemy() ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
