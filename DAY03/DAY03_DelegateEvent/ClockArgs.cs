namespace DelegateEvent
{
    public class ClockArgs : EventArgs
    {
        public ClockArgs(int hour, int minute, int second)
        {
            this.hour = hour;
            this.minute = minute;
            this.second = second;
        }

        private int hour;
        private int minute;
        private int second;
        public int Hour
        {
            get { return hour; }
        }
        public int Minute
        {
            get { return minute; }
        }
        public int Second
        {
            get { return second; }
        }

    }
}