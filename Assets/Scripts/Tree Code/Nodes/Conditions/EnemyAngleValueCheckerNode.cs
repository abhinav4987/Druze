using UnityEngine;

public class EnemyAngleLessThanValueCheckerNode : Node
{
    float angleValue = 0;

    public EnemyAngleLessThanValueCheckerNode(float angleValue)
    {
        this.angleValue = angleValue;
    }

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return shipParameters.parameters.GetAngleFromSelfToEnemy() < angleValue ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
