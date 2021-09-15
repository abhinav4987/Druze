using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Node
{

    protected NodeState _nodeState;

    public NodeState nodeState
    {
        get { return _nodeState; }
    }

    public abstract NodeState Evaluate(ShipAIParameters shipParameters, ShipAIActionControls shipControls);

}

public enum NodeState
{
    RUNNING, SUCCESS, FAILURE,
}


