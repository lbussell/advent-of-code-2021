namespace HydrothermalVenture
{
    public readonly struct VentLine
    {

        public int X1 { get; init; }
        public int Y1 { get; init; }
        public int X2 { get; init; }
        public int Y2 { get; init; }

        public (int, int) P1
        {
            get { return (X1, Y1); }
        }
        public (int, int) P2
        {
            get { return (X2, Y2); }
        }

        public VentLine((int x, int y) p1, (int x, int y) p2)
        {
            X1 = p1.x;
            Y1 = p1.y;
            X2 = p2.x;
            Y2 = p2.y;
        }

        public VentLine(int x1, int y1, int x2, int y2)
        {
            X1 = x1;
            Y1 = y1;
            X2 = x2;
            Y2 = y2;
        }

        public override string ToString()
        {
            return "VentLine " + (X1, Y1) + ", " + (X2, Y2);
        }
    }

}