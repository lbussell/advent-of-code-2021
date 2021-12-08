namespace BinaryDiagnostic
{

    class LifeSupportCalculator
    {

        public int CalculateOxygenGeneratorRating(string[] binaryInput)
        {
            return CalculateRatingRecursive(binaryInput, 0, true);
        }

        public int CalculateC02ScrubberRating(string[] binaryInput)
        {
            return CalculateRatingRecursive(binaryInput, 0, false);
        }

        private int CalculateRatingRecursive(string[] input, int index, bool mostCommon)
        {
            if (input.Length == 1)
            {
                return Convert.ToInt32(input[0], 2);
            }
            else
            {
                string[] ones = input.Where(s => s[index] == '1').ToArray();
                string[] zeros = input.Where(s => s[index] == '0').ToArray();

                string[] remaining;

                if (mostCommon) // oxygen generator
                {
                    remaining = ones.Length >= zeros.Length ? ones : zeros;
                }
                else // least common - c02 scrubber
                {
                    remaining = ones.Length < zeros.Length ? ones : zeros;
                }

                index += 1;

                return CalculateRatingRecursive(remaining, index, mostCommon);
            }
        }
    }

}