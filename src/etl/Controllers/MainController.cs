using System.Collections.Generic;
using etl.Library;
using Microsoft.AspNetCore.Mvc;

namespace etl.Controllers
{
    [Route("api/[controller]")]
    public class MainController : Controller
    {
        private CommandEngine _commandEngine;

        public MainController(ICommandStrategy commandStrategy) 
        {
            _commandEngine = new CommandEngine(commandStrategy);
        }
        // GET api/values
        [HttpGet]
        public IEnumerable<string> Get()
        {
            _commandEngine.Run();
            return new string[] { 
                "Executed: " + _commandEngine.ToString(),
                "in time: " + _commandEngine.GetRunTime().TotalMilliseconds
            };
        }        
    }
}
