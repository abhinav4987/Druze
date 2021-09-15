using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public abstract class Nodes
{

    protected NodeStates _nodeState;

    public NodeStates nodeState
    {
        get { return _nodeState; }
    }

      public abstract NodeStates Evaluate();

}

public enum NodeState
{
    RUNNING,SUCCESS,FAILURE,
}
