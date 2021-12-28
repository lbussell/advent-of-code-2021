namespace Lanternfish;

class Program
{
    static void Main(string[] args)
    {
        IEnumerable<int> lanternfishTimers = ReadInput(args[0]);
        IEnumerable<Lanternfish> lanternfishes = ParseInput(lanternfishTimers);

        var lanternfishWorld = new LanternfishWorld(lanternfishes);
        lanternfishWorld.Simulate(80);
        Console.WriteLine("Part 1 answer: {0}", lanternfishWorld.Count);

        var fastLanternfishWorld = new FastLanternfishWorld(lanternfishTimers);
        fastLanternfishWorld.Simulate(256);
        Console.WriteLine("Part 2 answer: {0}", fastLanternfishWorld.Count);
    }

    private static IEnumerable<int> ReadInput(string inputFile)
    {
        return File.ReadLines(inputFile)
            .ToArray()[0]
            .Split(',')
            .Select(s => int.Parse(s));
    }

    private static IEnumerable<Lanternfish> ParseInput(IEnumerable<int> startingTimers)
    {
        return startingTimers.Select(s => new Lanternfish(s));
    }
}