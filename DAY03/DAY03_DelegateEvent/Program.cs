namespace DelegateEvent
{
    public class Program
    {
        // TODO: Chưa hoàn thiện, đang chỉnh sửa
        static void Main(string[] args)
        {
            Clock p = new Clock();
            Display sa = new Display();

            sa.Sub(p); // sa đăng ký nhận sự kiện từ p
            while (!Console.KeyAvailable)
            {
                Thread.Sleep(1000);
                p.Send();
            }
        }
    }


    // Xây dựng lớp, phát đi sự kiện (data)
    public class Clock
    {
        // Tạo delegate
        public delegate void clockTick(object clock, MyEventArgs myEventArgs);
        // Tạo Event với EventHandler
        public event clockTick clockTickEvent;
        public void Send()
        {
            DateTime currentTime = DateTime.Now;
            clockTickEvent?.Invoke(this, new MyEventArgs(currentTime.Hour, currentTime.Minute, currentTime.Second));
        }
    }

    public class Display
    {
        public static void ShowClock(object clock, MyEventArgs myEventArgs)
        {
            DateTime currentTime = DateTime.Now;
            Console.WriteLine($"{myEventArgs.Hour}:{myEventArgs.Minute}:{myEventArgs.Second}");
        }
        public void Sub(Clock p)
        {
            p.clockTickEvent += new Clock.clockTick(ShowClock);
        }
    }

}
