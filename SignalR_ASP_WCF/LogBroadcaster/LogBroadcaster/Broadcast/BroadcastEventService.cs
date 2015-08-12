namespace LogBroadcaster.Broadcast
{
    public delegate void BroadcastEventHandler(object sender, BroadcastEventArgs e);

    public class BroadcastEventService
    {
        private static volatile BroadcastEventService _instance;
        private static object _mutex = new object();

        public event BroadcastEventHandler BroadcastStart;
        public event BroadcastEventHandler BroadcastEvent;
        public event BroadcastEventHandler BroadcastDone;
        #region constructor

        private BroadcastEventService()
        {
        }

        #endregion

        public static BroadcastEventService Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (_mutex)
                    {
                        if (_instance == null)
                        {
                            _instance = new BroadcastEventService();
                        }
                    }
                }
                return _instance;
            }
        }


        public void Broadcast(BroadcastEventArgs e)
        {
            if (BroadcastEvent != null)
            {
                BroadcastEvent(this, e);
            }
        }

        public void Start()
        {
            if (BroadcastStart != null)
            {
                BroadcastStart(this, null);
            }
        }

        public void Finished()
        {
            if (BroadcastDone != null)
            {
                BroadcastDone(this, null);
            }
        }
    }
}
