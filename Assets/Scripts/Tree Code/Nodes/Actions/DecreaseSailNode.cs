public class DecreaseSailNode : Node {
    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.DecreaseSail();
        return NodeState.SUCCESS;
    }
}


