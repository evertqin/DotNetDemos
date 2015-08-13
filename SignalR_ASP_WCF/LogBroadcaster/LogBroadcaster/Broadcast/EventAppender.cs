using log4net.Appender;
using log4net.Core;

namespace LogBroadcaster.Broadcast
{
    public class EventAppender : AppenderSkeleton
    {
        protected override void Append(LoggingEvent loggingEvent)
        {
            // we are coupling the info with the status indication, maybe we can consider using other levels, such as Notice to indicate progress
                BroadcastEventService.Instance.Broadcast(new BroadcastEventArgs
                {
                    DataTime = loggingEvent.TimeStamp,
                    Level = loggingEvent.Level.ToString(),
                    LoggerName = loggingEvent.LoggerName,
                    ThreadName = loggingEvent.ThreadName,
                    Message = loggingEvent.MessageObject.ToString(),
                });
        }
    }
}
