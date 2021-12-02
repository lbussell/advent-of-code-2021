namespace Dive;

class Program
{
    static void Main(string[] args)
    {
        var submarineInstructions = ReadInput(args[0]);

        Submarine sub = new Submarine();

        foreach (var instruction in submarineInstructions)
        {
            sub.ApplyInstruction(instruction);
        }

        Console.WriteLine("Final horizontal position: {0}", sub.horizontalPosition);
        Console.WriteLine("Final depth: {0}", sub.depth);
        Console.WriteLine("Multiplied: {0}", sub.horizontalPosition * sub.depth);
    }

    private static SubmarineInstruction[] ReadInput(string inputFile)
    {
        return File.ReadLines(inputFile).Select(line =>
        {
            string[] splitLine = line.Split(" ");
            return new SubmarineInstruction
            {
                direction = splitLine[0],
                value = int.Parse(splitLine[1])
            };
        }).ToArray();
    }
}