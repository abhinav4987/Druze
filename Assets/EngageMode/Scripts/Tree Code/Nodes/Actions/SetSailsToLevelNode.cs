public class SetSailsToLevelNode : Node {

    int targetSailLevel;

    public SetSailsToLevelNode(int targetSailLevel)
    {
        this.targetSailLevel = targetSailLevel;
    }

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        shipControls.SetSailLevel(targetSailLevel);
        return NodeState.SUCCESS;
    }
}