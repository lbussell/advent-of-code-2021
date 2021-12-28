using System.Text;
using Lanternfish.Extensions;

namespace Lanternfish
{
    public class FastLanternfishWorld
    {
        public long Count
        {
            get
            {
                return _fishBuckets.Sum();
            }
        }

        private List<long> _fishBuckets = new List<long>(Enumerable.Repeat<long>(0, 9));

        public FastLanternfishWorld(IEnumerable<int> startingTimers)
        {
            foreach (int n in startingTimers)
            {
                _fishBuckets[n] += 1;
            }
        }

        public void SimulateDay()
        {
            _fishBuckets = _fishBuckets.Rotate();
            _fishBuckets[6] += _fishBuckets[8];
        }

        public void Simulate(int days)
        {
            for (int n = 0; n < days; n++)
            {
                SimulateDay();
            }
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < _fishBuckets.Count; i++)
            {
                long numFish = _fishBuckets[i];
                for (int j = 0; j < numFish; j++)
                {
                    sb.Append(i);
                    sb.Append(',');
                }
            }
            return sb.ToString();
        }
    }
}