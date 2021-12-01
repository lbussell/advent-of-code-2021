
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
        var numberOfMeasurementIncreases = sonarSweep.RunSweep(input);

        Console.WriteLine("Part 1 answer: {0}", numberOfMeasurementIncreases);
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
    private int previous = int.MaxValue;
    private int count = 0;

    //
    // Computes how many measurements are larger than the previous measurement.
    //
    public int RunSweep(int[] measurements)
    {
        foreach(int n in measurements)
        {
            if (n > previous)
            {
                count += 1;
            }
            previous = n;
        }

        return count;
    }
}