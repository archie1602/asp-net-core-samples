namespace WebApp.States
{
    public class ConreteStateB : IState
    {
        public State State => State.STATE_B;

        public string Handle() => $"Handle {State}";
    }
}