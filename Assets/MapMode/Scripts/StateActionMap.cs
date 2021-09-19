using UnityEngine;

public static class StateActionMap
{
    private static float max_time_range = 8.0f;
    private static float mean_time = 4.0f;
    private static float max_explore_angle = 360;
    private static float deviation_strength = 0.4f;
    private static float speed = 0.5f;
    private static float sense_radius = 5f;

    public delegate void ActionDef(GameObject obj, ref StateDefinition.StateData s_data);

    private static void WaitInitializer(ref StateDefinition.StateData s_data)
    {        
        s_data.observations.waitingTime = Mathf.Max(0.0f, (Random.value - 0.5f) * max_time_range + mean_time);
        //Debug.Log(s_data.observations.waitingTime);
    }

    public static void Wait(GameObject obj, ref StateDefinition.StateData s_data)
    {
        s_data.observations.waitingTime -= Time.deltaTime;
    }

    private static void RoamInitializer(ref StateDefinition.StateData s_data)
    {
        s_data.observations.roamingDuration = Mathf.Max(0.0f, (Random.value - 0.5f)* max_time_range + mean_time);
    }

    public static void Roam(GameObject obj, ref StateDefinition.StateData s_data)
    {
        s_data.observations.roamingDuration -= Time.deltaTime;
        float desired_angle = (Random.value - 0.5f) * max_explore_angle;
        obj.transform.eulerAngles = obj.transform.eulerAngles + Vector3.forward * deviation_strength * desired_angle * Time.deltaTime;
        obj.transform.Translate( obj.transform.up * speed * Time.deltaTime);
    }

    public static void Chase(GameObject obj, ref StateDefinition.StateData s_data)
    {
        GetPlayerInformation plyInfo = obj.GetComponent<GetPlayerInformation>();
        float desired_angle = plyInfo.getPlayerAngle();
        obj.transform.eulerAngles = obj.transform.eulerAngles + obj.transform.forward * 0.2f * desired_angle * Time.deltaTime;
        obj.transform.Translate(obj.transform.up * speed * Time.deltaTime);
    }

    //method that returns the related action(delegate)
    public static ActionDef getAction(ref StateDefinition.StateData s_data)
    {
        //Debug.Log("Finding");
        switch (s_data.currState)
        {
            case StateDefinition.States.Wait:
                {//Return Action mapped with Wait State
                    WaitInitializer(ref s_data);
                    //Debug.Log("Waiting");
                    return Wait;
                }
            case StateDefinition.States.Roam:
                {//return Action mapped with Roam State
                    RoamInitializer(ref s_data);
                    //Debug.Log("Roaming");
                    return Roam;
                }
            case StateDefinition.States.Chase:
                {//return Action mapped with Chase State
                    Debug.Log("Chasing");
                    return Chase;
                }
            case StateDefinition.States.NoChange:
                {//Method control should not reach here, if it does then errors in calculations.

                }
                break;
            default://UNKNOWN STATE
                break;
        }
        return null;
    }

    public static int TestCall()
    {
        //Debug.Log("Tester");
        return 10;
    }
}
