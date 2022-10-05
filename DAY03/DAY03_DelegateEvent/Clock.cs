namespace DelegateEvent
{
    public class Clock
    {
        // create delegate
        public delegate void delegateClock(object clock, ClockArgs eventClockArgs);
        // create Event
        public event delegateClock? eventClock;
        public void Send()
        {
            DateTime currentTime = DateTime.Now;
            eventClock?.Invoke(this, new ClockArgs(currentTime.Hour, currentTime.Minute, currentTime.Second));
        }
    }
}

