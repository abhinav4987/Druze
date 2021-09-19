public static class StateDefinition
{
    //Enum of different AI states
    public enum States {
        Wait,
        Roam,
        NoChange,
        Chase
    }

    //Collection of all the observations required for state determination
    public struct Observations {
        public float waitingTime { get; set; }
        public float roamingDuration { get; set; }
        public bool playerVisible { get; set; }
    }

    //Collection of data related to a state
    public struct StateData {
        public States currState { get; set; }
        public Observations observations;
    }
}
