using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using WebApp.Providers;
using WebApp.States;

namespace WebApp.Resolvers
{
    public class Resolver : IResolver
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly Dictionary<State, Type> _states;

        public Resolver(IServiceProvider serviceProvider, Dictionary<State, Type> states)
        {
            _serviceProvider = serviceProvider;
            _states = states;
        }

        public IState Resolve(State state)
        {
            _states.TryGetValue(state, out var stateType);

            var ctors = stateType.GetConstructors();

            if (ctors.Length == 2)
            {
                var ctorWithParameters = ctors[1];
                var ctorParameters = ctorWithParameters.GetParameters();

                if (ctorParameters.Length == 0)
                {
                    ctorWithParameters = ctors[0];
                    ctorParameters = ctorWithParameters.GetParameters();
                }

                var ctorArgs = new object[ctorParameters.Length];

                foreach (var p in ctorParameters)
                {
                    ctorArgs[p.Position] = _serviceProvider.GetService(p.ParameterType);
                }

                var objInstance = Activator.CreateInstance(stateType, ctorArgs);

                return objInstance as IState;
            }

            return Activator.CreateInstance(stateType) as IState;
        }
    }
}