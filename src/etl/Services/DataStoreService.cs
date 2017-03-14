using System.Threading.Tasks;
using etl.Models;
using etl.Repositories;

namespace etl.Services
{
    public class DataStoreService
    {
        private readonly IDataStoreRepository _dataStoreRepository;

        public DataStoreService(IDataStoreRepository dataStoreRepository)
        {
            _dataStoreRepository = dataStoreRepository;
        }

        public async Task<DataStoreItem> Get(string JobID)
        {
            return await _dataStoreRepository.Read(JobID);
        }

        public async Task<bool> Save(DataStoreItem item)
        {
            return await _dataStoreRepository.Write(item);
        }
    }
}