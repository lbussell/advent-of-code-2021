namespace HydrothermalVenture
{
    public struct VentMap
    {
        private int[,] _map;
        private int _size;

        public VentMap(int size)
        {
            _size = size;
            _map = new int[size, size];
        }

        public VentMap() : this(1000) { }

        public void ApplyVentLine(VentLine line)
        {
            // line is vertical
            if (line.X1 == line.X2)
            {
                foreach (int y in Sequence(line.Y1, line.Y2))
                {
                    _map[line.X1, y] += 1;
                }
            }
            // line is horizontal
            else if (line.Y1 == line.Y2)
            {
                foreach (int x in Sequence(line.X1, line.X2))
                {
                    _map[x, line.Y1] += 1;
                }
            }
            else
            {
                int[] seq1 = Sequence(line.X1, line.X2);
                int[] seq2 = Sequence(line.Y1, line.Y2);
                for (int i = 0; i < seq1.Length; i++)
                {
                    _map[seq1[i], seq2[i]] += 1;
                }
            }
        }

        public int CountOverlaps()
        {
            int overlaps = 0;

            for (int i = 0; i < _size; i++)
            {
                for (int j = 0; j < _size; j++)
                {
                    if (_map[i, j] >= 2)
                    {
                        overlaps += 1;
                    }
                }
            }

            return overlaps;
        }

        public static int[] Sequence(int start, int end)
        {
            int len = Math.Abs(end - start);
            if (start < end)
            {
                return Enumerable.Range(start, len + 1).ToArray();
            }
            else // go in reverse
            {
                return Enumerable.Range(end, len + 1).Reverse().ToArray();
            }
        }
    }

}