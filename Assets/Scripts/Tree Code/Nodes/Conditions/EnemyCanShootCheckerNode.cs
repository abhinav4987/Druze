using UnityEngine;

public class EnemyCanShootCheckerNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {

        float angle = shipParameters.parameters.GetAngleFromEnemyToSelf();
        float allowedShootAngleMagnitude = 5f, dangerAngleValue = 90f;
        return Mathf.Abs(angle - dangerAngleValue) < allowedShootAngleMagnitude ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}