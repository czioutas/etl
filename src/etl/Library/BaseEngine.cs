using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace etl.Library
{
    public abstract class BaseEngine
    {
        private Stopwatch _sw;

        public BaseEngine()
        {
            _sw = new Stopwatch();
        }

        public async Task Run(string jobID)
        {
            _sw.Start();
            await Execute(jobID);
            _sw.Stop();
        }

        public TimeSpan GetRunTime()
        {
            return _sw.Elapsed;
        }

        protected abstract Task Execute(string jobID);
    }
}