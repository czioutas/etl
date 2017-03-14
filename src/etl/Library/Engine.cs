using System;
using System.Threading.Tasks;
using etl.Models;
using etl.Services;
using etl.Strategies;

namespace etl.Library
{
    public class Engine : BaseEngine
    {
        private readonly DataStoreService _dataStoreService;
        private readonly IStrategy _strategy;
        public Engine(
            IStrategy strategy,
            DataStoreService dataStoreService)
        {
            _dataStoreService = dataStoreService;
            _strategy = strategy;
            Console.WriteLine(_strategy.GetType().Name);
        }

        protected override async Task Execute(string jobID)
        {
            DataStoreItem readDsi = await GetRelevantData(jobID);
            DataStoreItem outputDsi = await _strategy.Work(readDsi);
            await StoreRelevantData(outputDsi);
        }

        protected async Task<bool> StoreRelevantData(DataStoreItem dsi)
        {
            return await _dataStoreService.Save(dsi);
        }

        protected async Task<DataStoreItem> GetRelevantData(string jobID)
        {
            return await _dataStoreService.Get(jobID);
        }
    }
}