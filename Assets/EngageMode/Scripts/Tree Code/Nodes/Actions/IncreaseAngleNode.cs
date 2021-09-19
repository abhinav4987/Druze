public class IncreaseAngleNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.IncreaseCannonAngle();
        return NodeState.SUCCESS;
    }
}