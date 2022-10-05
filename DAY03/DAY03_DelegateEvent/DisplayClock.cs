namespace DelegateEvent
{
    public class DisplayClock
    {
        public static void ShowClock(object clock, ClockArgs currentTime)
        {
            Console.WriteLine($"{currentTime.Hour}:{currentTime.Minute}:{currentTime.Second}");
        }

        public void Sub(Clock p)
        {
            p.eventClock += new Clock.delegateClock(ShowClock);
        }
    }
}

