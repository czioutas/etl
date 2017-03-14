using System.Collections.Generic;
using System.Threading.Tasks;
using etl.Library;
using etl.Strategies;

namespace etl.Services
{
    public class EtlService
    {
        private readonly DataStoreService _dataStoreService;

        public EtlService(DataStoreService dataStoreService)
        {
            _dataStoreService = dataStoreService;
        }

        public async Task<IEnumerable<Engine>> Full(string jobID)
        {
            return new Engine[] { 
                await Populate(jobID),
                await Hydrate(jobID)
            };
        }

        public async Task<Engine> Hydrate(string jobID)
        {
            Engine _engine = new Engine(new HydrateStrategy(), _dataStoreService);
            await _engine.Run(jobID);
            return _engine;
        }

        public async Task<Engine> Populate(string jobID)
        {
            Engine _engine = new Engine(new PopulateStrategy(), _dataStoreService);
            await _engine.Run(jobID);
            return _engine;
        }
    }
}