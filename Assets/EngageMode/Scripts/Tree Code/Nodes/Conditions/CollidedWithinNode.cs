using UnityEngine;

public class CollidedWithinNode : Node
{
    private float collidedCheckerTimeValue;

    public CollidedWithinNode(float collidedCheckerTimeValue)
    {
        this.collidedCheckerTimeValue = collidedCheckerTimeValue;
    }

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        return (Time.time - shipParameters.parameters.GetPreviousRamCollisionTime()) < collidedCheckerTimeValue ? NodeState.SUCCESS : NodeState.FAILURE;
    }
}
