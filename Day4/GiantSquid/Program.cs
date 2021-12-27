using System.Text.RegularExpressions;

namespace GiantSquid
{

    class Program
    {
        static void Main(string[] args)
        {
            string[] rawInput = ReadInput(args[0]);

            (BingoBoard[] boards, int[] randomDraws) = ParseInput(rawInput);

            BingoBoard? firstWinningBoard = FindFirstWinningBoard(boards, randomDraws);

            if (firstWinningBoard is not null)
            {
                int boardScore = firstWinningBoard.CalculateScore();

                Console.WriteLine("First winning board:");
                Console.WriteLine(firstWinningBoard);
                Console.WriteLine("\nBoard Score: {0}\n", boardScore);
            }

            foreach (BingoBoard board in boards)
            {
                board.Reset();
            }

            BingoBoard? lastWinningBoard = FindLastWinningBoard(boards, randomDraws);

            if (lastWinningBoard is not null)
            {
                int boardScore = lastWinningBoard.CalculateScore();

                Console.WriteLine("Last winning board:");
                Console.WriteLine(lastWinningBoard);
                Console.WriteLine("\nBoard Score: {0}\n", boardScore);
            }
        }

        private static (BingoBoard[], int[]) ParseInput(string[] input)
        {
            int[] randomDraws = input[0].Split(',')
                    .Select(s => int.Parse(s))
                    .ToArray();

            string[] boardStrings = input.Skip(2).ToArray();
            int numBoards = (boardStrings.Length + 1) / (BingoBoard.BoardSize + 1);

            Console.WriteLine("Random draws: {0}", String.Join(',', randomDraws));
            Console.WriteLine("Number of boards: {0}", numBoards);

            BingoBoard[] boards = new BingoBoard[100];

            Regex spaceRegex = new Regex(" +");

            for (int b = 0; b < numBoards; b++)
            {
                int[,] newBoard = new int[BingoBoard.BoardSize, BingoBoard.BoardSize];

                int[][] lines = new int[BingoBoard.BoardSize][];

                for (int l = 0; l < BingoBoard.BoardSize; l++)
                {
                    lines[l] = spaceRegex.Split(boardStrings[l].TrimStart(' '))
                            .Select(s => int.Parse(s))
                            .ToArray();
                }

                boards[b] = new BingoBoard(lines);
                boardStrings = boardStrings.Skip(BingoBoard.BoardSize + 1).ToArray();
            }

            return (boards, randomDraws);
        }

        private static string[] ReadInput(string inputFile)
        {
            return File.ReadLines(inputFile).ToArray();
        }

        private static BingoBoard? FindFirstWinningBoard(BingoBoard[] boards, int[] randomDraws)
        {
            foreach (int n in randomDraws)
            {
                foreach (BingoBoard board in boards)
                {
                    bool win = board.Mark(n);

                    if (win)
                    {
                        return board;
                    }
                }
            }
            return null;
        }

        private static BingoBoard? FindLastWinningBoard(BingoBoard[] boards, int[] randomDraws)
        {
            int numBoards = boards.Length;
            int numWinningBoards = 0;

            foreach (int n in randomDraws)
            {
                foreach (BingoBoard board in boards)
                {
                    if (!board.IsWinning)
                    {
                        bool win = board.Mark(n);

                        if (win)
                        {
                            numWinningBoards += 1;

                            if (numWinningBoards == boards.Length)
                            {
                                return board;
                            }
                        }
                    }
                }
            }
            return null;
        }
    }
}