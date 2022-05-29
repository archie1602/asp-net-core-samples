namespace WebApp.States
{
    public interface IState
    {
        public State State { get; }

        string Handle();
    }
}