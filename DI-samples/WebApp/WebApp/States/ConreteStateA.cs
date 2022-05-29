using WebApp.Providers;

namespace WebApp.States
{
    public class ConreteStateA : IState
    {
        public State State => State.STATE_A;

        private readonly IProvider _provider;
        private readonly ILogger<ConreteStateA> _logger;

        public ConreteStateA() { }

        public ConreteStateA(IProvider provider, ILogger<ConreteStateA> logger)
        {
            _provider = provider;
            _logger = logger;
        }

        public string Handle() => $"Handle {State} and {_provider.GetSomeData()}";
    }
}