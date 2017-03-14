using System.Threading;
using System.Threading.Tasks;
using etl.Models;

namespace etl.Strategies
{
    public class PopulateStrategy : IStrategy
    {
        async Task<DataStoreItem> IStrategy.Work(DataStoreItem dsi)
        {
            Thread.Sleep(100);

            dsi.Data = "yo";

            return dsi;
        }
    }
}