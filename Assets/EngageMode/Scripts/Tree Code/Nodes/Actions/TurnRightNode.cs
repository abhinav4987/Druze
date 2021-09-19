public class TurnRightNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.TurnRight();
        return NodeState.SUCCESS;
    }
}