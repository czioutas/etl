using System.Collections.Generic;
using etl.Services;
using etl.Library;
using etl.Strategies;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System;
using System.Threading.Tasks;

namespace etl.Controllers
{
    [Route("api/[controller]/[action]")]
    public class EngineController : Controller
    {
        private readonly EtlService _etlService;
        public EngineController(EtlService etlService) 
        {
            _etlService = etlService;
        }

        // GET api/full/{id}
        [HttpGet("{id}")]
        public async Task<IEnumerable<string>> Full(string id)
        {            
            IEnumerable<Engine> _engineCollection = await _etlService.Full(id);
            double ts = _engineCollection.Sum(e => e.GetRunTime().TotalMilliseconds);
            return new string[] { 
                "run " +  this.GetType().FullName,
                "time " + ts };
        }   
        
        // GET api/populate/{id}
        [HttpGet("{id}")]
        public async Task<IEnumerable<string>> Populate(string id)
        {            
            Engine _engine = await _etlService.Populate(id);
            return new string[] { "run Population", "time " + _engine.GetRunTime().TotalMilliseconds };
        }   

        // GET api/hydrate/{id}
        [HttpGet("{id}")]
        public async Task<IEnumerable<string>> Hydrate(string id)
        {
            Engine _engine = await _etlService.Hydrate(id);
            return new string[] { "run Hydration", "time " + _engine.GetRunTime().TotalMilliseconds };
        }     
    }
}
