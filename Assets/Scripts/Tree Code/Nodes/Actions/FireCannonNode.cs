using UnityEngine;
public class FireCannonNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        Vector3 relativePoint = shipParameters.parameters.GetEnemyRelativeFromSelf();

        if (relativePoint.z < 0){
            // ENEMY towards Right
            shipControls.FireCannon(1);
        } else if (relativePoint.z > 0){
            // ENEMY in Left
            shipControls.FireCannon(0);
        }

        return NodeState.SUCCESS;
    }
}