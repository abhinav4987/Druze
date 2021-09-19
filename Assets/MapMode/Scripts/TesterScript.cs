using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TesterScript : MonoBehaviour
{
    private StateDefinition.StateData s_data;
    private StateDefinition.States determinedState;
    private StateActionMap.ActionDef act;
    // Start is called before the first frame update
    void Start()
    {
        s_data = new StateDefinition.StateData();
        act = null;
        s_data.currState = StateDefinition.States.Wait;
        s_data.observations.waitingTime = 2.0f;
        s_data.observations.roamingDuration = 2.0f;
    }
    void Update()
    {
        determinedState = StateDeterminer.determineState(gameObject,s_data);
    }
    void FixedUpdate()
    {
        //print(determinedState+" w : "+s_data.observations.waitingTime+" r : " +s_data.observations.roamingDuration);

        if (determinedState != StateDefinition.States.NoChange)
        {
            s_data.currState = determinedState;
            act = StateActionMap.getAction(ref s_data);
        }
        act.Invoke(gameObject, ref s_data);
    }
}
