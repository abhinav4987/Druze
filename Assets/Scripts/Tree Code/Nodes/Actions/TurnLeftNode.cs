public class TurnLeftNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.TurnLeft();
        return NodeState.SUCCESS;
    }
}