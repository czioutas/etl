using System;
using System.Threading;
using etl.Library;

namespace etl.Commands
{
    public class TestCommand : AbstractCommand
    {
        public override void Execute()
        {
            Thread.Sleep(200);
        }
    }
}