using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApp.States;

namespace WebApp.Resolvers
{
    public interface IResolver
    {
        IState Resolve(State State);
    }
}