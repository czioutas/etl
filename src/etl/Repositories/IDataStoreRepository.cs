using System.Threading.Tasks;
using etl.Models;

namespace etl.Repositories
{
    public interface IDataStoreRepository
    {
        Task<DataStoreItem> Read(string jobID);
        Task<bool> Write(DataStoreItem item);
    }
}