namespace Lanternfish
{
    public class Lanternfish
    {
        private static readonly int _resetTimerValue = 6;
        private static readonly int _newTimerValue = 8;

        private int _timer;

        public Lanternfish(int timerValue)
        {
            _timer = timerValue;
        }

        public Lanternfish() : this(Lanternfish._newTimerValue) { }

        public Lanternfish? Age()
        {
            if (_timer == 0)
            {
                _timer = Lanternfish._resetTimerValue;
                return new Lanternfish();
            }
            _timer -= 1;
            return null;
        }

        public override string ToString()
        {
            return _timer.ToString();
        }
    }
};
