using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using etl.Models;
using Microsoft.Extensions.Caching.Distributed;

namespace etl.Repositories
{
    public class DataStoreRepository : IDataStoreRepository
    {
        private readonly IDistributedCache _distributedCache;
        private DistributedCacheEntryOptions _distributedCacheOptions;

        private readonly Stopwatch _sw;
        
        public DataStoreRepository(IDistributedCache distributedCache)
        {
            _distributedCache = distributedCache;
            _distributedCacheOptions = new DistributedCacheEntryOptions();
            _sw = new Stopwatch();
        }

        async Task<DataStoreItem> IDataStoreRepository.Read(string jobID)
        {
            DataStoreItem dsi = new DataStoreItem();
            dsi.JobID = jobID;

            _sw.Start();
            dsi.Data = await _distributedCache.GetStringAsync(jobID);
            _sw.Stop();
            Debug.WriteLine(_sw.Elapsed);

            return dsi;
        }

        async Task<bool> IDataStoreRepository.Write(DataStoreItem item)
        {
            _sw.Start();
            await _distributedCache.SetStringAsync(item.JobID, item.Data, _distributedCacheOptions);            
            _sw.Stop();
            Debug.WriteLine(_sw.Elapsed);
            return true;
        }
    }
}