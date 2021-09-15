using System.Collections;
using System.Collection.Generic;
using UnityEngine;

public class FireCannon : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        Vector3 relativePoint = shipParameters.parameters.enemyTransform.InverseTransformPoint(0, 0, 0);

        if (relativePoint.x > 0){
            //ENEMY TOWARDS RIGHT;
            shipControls.FireCannon();
        } else if (relativePoint.x > 0){
            // ENEMY INFRONT 
            shipControls.FireCannon();
        }
        else{
            // ENEMY TOWARDS LEFT
            shipControls.FireCannon();
        }

        shipControls.FireCannon();
        return NodeState.SUCCESS;
    }
}