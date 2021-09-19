public class DecreaseAngleNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.DecreaseCannonAngle();
        return NodeState.SUCCESS;
    }
}