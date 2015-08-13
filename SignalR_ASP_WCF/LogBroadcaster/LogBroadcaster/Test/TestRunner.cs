using System;
using System.Timers;
using log4net;

namespace LogBroadcaster.Test
{
    public class TestRunner
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(TestRunner));

        private Timer timer;

        public TestRunner()
        {
            timer = new Timer();
        }
        public void GeneratingRandomLog()
        {
            Random rand = new Random();
            double interval = rand.NextDouble() * 10000;

            timer.Interval = interval;
            timer.Elapsed += (sender, eventArgs) =>
            {
                _log.Warn(string.Format("This is a test. Now timer is {0}", eventArgs.SignalTime));
            };
            timer.Start();
        }
    }
}
