namespace DelegateEvent
{
    public class DisplayClock
    {
        public void Subcribe(Clock clock)
        {
            clock.clockTick += new Clock.clockTickHandler(ShowClock);
        }

        public static void ShowClock(object clock, ClockEventArgs currentTime)
        {
            Console.WriteLine($"{currentTime.hour}:{currentTime.minute}:{currentTime.second}");
        }
    }
}

