using System;
using System.Diagnostics;

namespace etl.Library
{
    public abstract class AbstractCommand : ICommand
    {
        private readonly Stopwatch _sw;
        public AbstractCommand()
        {
            _sw = new Stopwatch();
        }

        public void Run()
        {
            _sw.Start();
            Execute();
            _sw.Stop();
        }

        public TimeSpan GetRunTime()
        {
            return _sw.Elapsed;
        }

        public abstract void Execute();
    }
}