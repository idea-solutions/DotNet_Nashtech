namespace DelegateEvent
{
    public class Program
    {
        static void Main(string[] args)
        {
            Clock clock = new Clock();
            DisplayClock displayClock = new DisplayClock();

            displayClock.Sub(clock);

            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                clock.Send();
            }
        }
    }
}
