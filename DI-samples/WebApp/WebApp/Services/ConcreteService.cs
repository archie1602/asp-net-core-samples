using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.Resolvers;
using WebApp.States;

namespace WebApp.Services
{
    public class ConcreteService : IService
    {
        public readonly IResolver _resolver;

        public ConcreteService(IResolver resolver) => _resolver = resolver;

        public string DoSomeAction(State someState)
        {
            // get concrete object state using someState value
            var stateInstance = _resolver.Resolve(someState);

            // perform some action on this state and take result
            var stateResult = stateInstance.Handle();

            return stateResult;
        }
    }
}
