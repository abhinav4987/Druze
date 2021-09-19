public class IncreaseSailNode : Node {

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.IncreaseSail();
        return NodeState.SUCCESS;
    }
}