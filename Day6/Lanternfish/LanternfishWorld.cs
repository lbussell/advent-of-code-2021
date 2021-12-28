namespace Lanternfish
{
    public class LanternfishWorld
    {
        public int Count
        {
            get
            {
                return _lanternfishes.Count;
            }
        }

        private List<Lanternfish> _lanternfishes = new List<Lanternfish>();

        public LanternfishWorld(IEnumerable<Lanternfish> startingLanternfishes)
        {
            _lanternfishes.AddRange(startingLanternfishes);
        }

        public void SimulateDay()
        {
            List<Lanternfish> newLanternfishes = new List<Lanternfish>();

            foreach (Lanternfish lf in _lanternfishes)
            {
                Lanternfish? newLf = lf.Age();
                if (newLf is not null)
                {
                    newLanternfishes.Add(newLf);
                }
            }

            _lanternfishes.AddRange(newLanternfishes);
        }

        public void Simulate(int days)
        {
            foreach (int _ in Enumerable.Range(1, days))
            {
                SimulateDay();
            }
        }

        public override string ToString()
        {
            return String.Join(',', _lanternfishes);
        }
    }
}