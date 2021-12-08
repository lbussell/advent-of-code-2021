namespace BinaryDiagnostic
{

    class PowerConsumptionCalculator
    {
        private string mostCommonChars;

        public uint CalculateGammaRate(string[] binaryInput)
        {
            int inputLength = binaryInput.Length;
            int binaryNumberLength = binaryInput[0].Length;

            char[] binaryGammaRate = new char[binaryNumberLength];

            for (int i = 0; i < binaryNumberLength; i++)
            {
                int ones = CountOnes(binaryInput, i);

                if (ones > inputLength / 2)
                {
                    binaryGammaRate[i] = '1';
                }
                else
                {
                    binaryGammaRate[i] = '0';
                }
            }

            mostCommonChars = new string(binaryGammaRate);

            uint gammaRate = Convert.ToUInt32(mostCommonChars, 2);

            return gammaRate;
        }

        public uint CalculateEpsilonRate(string[] binaryInput)
        {
            if (mostCommonChars is null)
            {
                CalculateGammaRate(binaryInput);
            }
            else
            {
                Console.WriteLine("Most common: {0}", mostCommonChars);
                return Convert.ToUInt32(InvertBinaryString(mostCommonChars), 2);
            }
            return 0; // something went wrong if we reach this
        }

        public static int CountOnes(string[] binaryInput, int index)
        {
            int ones = 0;

            for (int i = 0; i < binaryInput.Length; i++)
            {
                if (binaryInput[i][index] == '1')
                {
                    ones += 1;
                }
            }

            return ones;
        }

        public static int CountZeros(string[] binaryInput, int index)
        {
            return binaryInput.Length - CountOnes(binaryInput, index);
        }

        private string InvertBinaryString(string s)
        {
            char[] invertedString = new char[s.Length];

            for (int i = 0; i < s.Length; i++)
            {
                invertedString[i] = s[i] == '1' ? '0' : '1';
            }

            return new string(invertedString);
        }
    }
}
