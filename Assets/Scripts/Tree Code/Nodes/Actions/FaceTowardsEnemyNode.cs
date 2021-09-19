using UnityEngine;

public class FaceTowardsEnemyNode : Node
{
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        float allowedRangeMagnitude = 0.3f;

        Vector3 enemyrelative = shipParameters.parameters.GetEnemyRelativeFromSelf();

        if (Mathf.Abs(enemyrelative.z) > allowedRangeMagnitude)
            shipControls.ExtremeRotation(leftDir: enemyrelative.z > 0);

        return NodeState.SUCCESS;
    }
}
