using System.Text.RegularExpressions;

namespace HydrothermalVenture
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] rawInput = ReadInput(args[0]);

            VentLine[] ventLines = ParseInput(rawInput);

            VentMap ventMap = new VentMap();

            foreach (VentLine vl in ventLines)
            {
                ventMap.ApplyVentLine(vl);
            }

            int overlaps = ventMap.CountOverlaps();
            Console.WriteLine("\nOverlaps: {0}\n", overlaps);
        }

        private static string[] ReadInput(string inputFile)
        {
            return File.ReadLines(inputFile).ToArray();
        }

        private static VentLine[] ParseInput(string[] rawInput)
        {
            return rawInput.Select(s =>
            {
                string[] splitInput = s.Split(" -> ");
                string[] splitLeft = splitInput[0].Split(',');
                string[] splitRight = splitInput[1].Split(',');
                int x1 = int.Parse(splitLeft[0]);
                int y1 = int.Parse(splitLeft[1]);
                int x2 = int.Parse(splitRight[0]);
                int y2 = int.Parse(splitRight[1]);
                return new VentLine(x1, y1, x2, y2);
            }).ToArray();
        }
    }
}
