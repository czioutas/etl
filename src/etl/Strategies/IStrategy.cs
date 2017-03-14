using System.Threading.Tasks;
using etl.Models;

namespace etl.Strategies
{
    public interface IStrategy
    {
        Task<DataStoreItem> Work(DataStoreItem dsi);
    }
}