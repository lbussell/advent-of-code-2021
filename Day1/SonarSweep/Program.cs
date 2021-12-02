
namespace SonarSweep;

class Program
{
    static void Main(string[] args)
    {
        if (args is null || args.Length == 0)
        {
            Console.WriteLine("Pass in the input file as an argument.");
            return;
        }

        var input = Program.ReadInput(args[0]);

        var sonarSweep = new SonarSweep();
        var numberOfMeasurementIncreases = sonarSweep.ComputeIncreases(input);

        Console.WriteLine("Part 1 answer: {0}", numberOfMeasurementIncreases);

        var slidingWindowIncreases = sonarSweep.ComputeSlidingWindowIncreases(input);

        Console.WriteLine("Part 2 answer: {0}", slidingWindowIncreases);
    }

    private static int[] ReadInput(string inputFile)
    {
        return File.ReadLines(inputFile)
            .Select(int.Parse)
            .ToArray();
    }
}

class SonarSweep
{
    //
    // Computes how many measurements are larger than the previous measurement.
    //
    public int ComputeIncreases(int[] measurements)
    {
        int previous = int.MaxValue;
        int count = 0;

        foreach (int n in measurements)
        {
            if (n > previous)
            {
                count += 1;
            }
            previous = n;
        }

        return count;
    }

    public int ComputeSlidingWindowIncreases(int[] measurements)
    {
        Func<int[], int, int[][]> windowed = (array, n) =>
        {
            int[][] windowedArray = new int[array.Length - (n - 1)][];

            for (int i = 0; i < array.Length - 2; i++)
            {
                windowedArray[i] = new int[n];
                windowedArray[i][0] = array[i];
                windowedArray[i][1] = array[i + 1];
                windowedArray[i][2] = array[i + 2];
            }

            return windowedArray;
        };

        return ComputeIncreases(windowed(measurements, 3).Select(w => w.Sum()).ToArray());
    }

}