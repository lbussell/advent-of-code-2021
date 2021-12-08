namespace BinaryDiagnostic {

    class Program
    {
        static void Main(string[] args)
        {
            string[] binaryInput = ReadInput(args[0]);

            PowerConsumptionCalculator powerCalculator = new PowerConsumptionCalculator();

            uint gammaRate = powerCalculator.CalculateGammaRate(binaryInput);
            uint epsilonRate = powerCalculator.CalculateEpsilonRate(binaryInput);

            Console.WriteLine("\nGamma rate: {0}", gammaRate);
            Console.WriteLine("Epsilon rate: {0}", epsilonRate);
            Console.WriteLine("Multiplied: {0}\n", gammaRate * epsilonRate);

            
            LifeSupportCalculator lsc = new LifeSupportCalculator();

            int oxygenGeneratorRating = lsc.CalculateOxygenGeneratorRating(binaryInput);
            int co2ScrubberRating = lsc.CalculateC02ScrubberRating(binaryInput);

            Console.WriteLine("Oxygen Rating: {0}", oxygenGeneratorRating);
            Console.WriteLine("C02 Rating: {0}", co2ScrubberRating);
            Console.WriteLine("Multiplied: {0}\n", oxygenGeneratorRating * co2ScrubberRating);
        }

        private static string[] ReadInput(string inputFile)
        {
            return File.ReadLines(inputFile).ToArray();
        }
    }
}