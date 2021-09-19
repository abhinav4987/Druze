using UnityEngine;
public static class StateDeterminer
{
    private static float sense_radius = 2.4f;
    //State Changer function when current State is Wait
    private static StateDefinition.States getNextState_Wait(GameObject obj,StateDefinition.Observations obs)
    {
        GetPlayerInformation plyInfo = obj.GetComponent<GetPlayerInformation>();
        if (plyInfo.getPlayerDistance() <= sense_radius)
        {
            return StateDefinition.States.Chase;
        }
        if (obs.waitingTime <= 0)
        {
            return StateDefinition.States.Roam;
        }
        return StateDefinition.States.NoChange;
    }

    //State Changer function when current State is Roam
    private static StateDefinition.States getNextState_Roam(GameObject obj, StateDefinition.Observations obs)
    {
        GetPlayerInformation plyInfo = obj.GetComponent<GetPlayerInformation>();
        if (plyInfo.getPlayerDistance() <= sense_radius)
        {
            return StateDefinition.States.Chase;
        }
        if (obs.roamingDuration <= 0)
        {
            return StateDefinition.States.Wait;
        }
        return StateDefinition.States.NoChange;
    }

    private static StateDefinition.States getNextState_Chase(GameObject obj, StateDefinition.Observations obs)
    {
        GetPlayerInformation plyInfo = obj.GetComponent<GetPlayerInformation>();
        if (plyInfo.getPlayerDistance() > sense_radius)
        {
            return StateDefinition.States.Wait;
        }
        return StateDefinition.States.NoChange;
    }

    //Function to determine the next State
    public static StateDefinition.States determineState(GameObject obj,StateDefinition.StateData s_data)
    {
        switch (s_data.currState)
        {
            //Wait is the current state
            case StateDefinition.States.Wait:
                {
                    //Check observations for state change
                    return getNextState_Wait(obj,s_data.observations);
                }

            //Roam is the current state
            case StateDefinition.States.Roam:
                {
                    //Check observations for state change
                    return getNextState_Roam(obj,s_data.observations);
                }

            case StateDefinition.States.Chase:
                {
                    //Check observations for state change
                    return getNextState_Chase(obj,s_data.observations);
                }

            //NoChange is the current state
            case StateDefinition.States.NoChange:
                {
                    //Error in calculations, cause this block should never be true
                }
                break;

            default: //UNKNOWN STATE FOUND
                break;
        }
        return StateDefinition.States.NoChange;
    }
}
