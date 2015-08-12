using System;

namespace LogBroadcaster.Broadcast
{
    public class BroadcastEventArgs : EventArgs
    {
        public DateTime DataTime { get; set; }
        public string Level { get; set; }
        public string LoggerName { get; set; }
        public string ThreadName { get; set; }
        public string Message { get; set; }
    }
}
