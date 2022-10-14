namespace DelegateEvent
{
    public class Clock
    {

        public delegate void clockTickHandler(object clock, ClockEventArgs clocEventkArgs);
        public event clockTickHandler? clockTick;

        protected void OnTick(object clock, ClockEventArgs clockEventArgs)
        {
            clockTick?.Invoke(this.clockTick, clockEventArgs);
        }

        public void Run()
        {
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                var currentTime = DateTime.Now;
                var clockEventArgs = new ClockEventArgs(currentTime.Hour, currentTime.Minute, currentTime.Second);
                OnTick(this, clockEventArgs);
            }
        }
    }
}

