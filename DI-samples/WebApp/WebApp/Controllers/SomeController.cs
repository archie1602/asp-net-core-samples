using Microsoft.AspNetCore.Mvc;
using WebApp.Services;
using WebApp.States;

namespace WebApp.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SomeController
    {
        public readonly IService _service;

        public SomeController(IService service)
        {
            _service = service;
        }

        [HttpGet("{state}")]
        public object GetState(string state)
        {
            if (Enum.TryParse<State>(state, true, out var res))
            {
                var actionResult = _service.DoSomeAction(res);

                return new { handle_state = actionResult };
            }

            return new { error = "State does not exist!" };
        }
    }
}
