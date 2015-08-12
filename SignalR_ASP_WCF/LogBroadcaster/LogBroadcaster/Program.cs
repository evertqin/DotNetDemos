using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogBroadcaster.Test;

namespace LogBroadcaster
{
    class Program
    {
        static void Main(string[] args)
        {
            TestRunner testRunner = new TestRunner();
            testRunner.GeneratingRandomLog();

            Console.ReadKey();
        }
    }
}
