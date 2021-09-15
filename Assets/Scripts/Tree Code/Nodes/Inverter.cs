using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inverter : Node
{
    protected Node node;

    public Inverter(Node node)
    {
        this.node = node;
    }

    public override NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls)
    {
        
            switch (node.Evaluate(shipParameters, shipControls))
            {
                case NodeState.RUNNING:
                _nodeState = NodeState.RUNNING;
                    break;
                case NodeState.SUCCESS:
                _nodeState = NodeState.FAILURE;
                    break;
                case NodeState.FAILURE:
                _nodeState = NodeState.SUCCESS;
                    break;
            }
       
        return _nodeState;
    }
}
