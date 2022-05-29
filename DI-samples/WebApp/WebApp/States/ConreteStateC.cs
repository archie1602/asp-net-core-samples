namespace WebApp.States
{
    public class ConreteStateC : IState
    {
        public State State => State.STATE_C;

        public string Handle() => $"Handle {State}";
    }
}