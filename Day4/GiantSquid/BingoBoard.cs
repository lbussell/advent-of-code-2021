using System.Text;

namespace GiantSquid
{

    class BingoBoard
    {

        public static int BoardSize = 5;

        public bool IsWinning = false;

        private int[,] _board;
        private bool[,] _marked;
        private int _winningNumber;

        public BingoBoard()
        {
            _board = new int[BoardSize, BoardSize];
            _marked = new bool[BoardSize, BoardSize];
        }

        public BingoBoard(int[][] startingBoard)
        {
            _board = new int[BoardSize, BoardSize];
            _marked = new bool[BoardSize, BoardSize];

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    _board[i, j] = startingBoard[i][j];
                }
            }
        }

        /// <summary>
        /// Mark a number on the bingo board and return true if the board becomes winning as a result.  
        /// </summary>
        /// <param name="n">The number to mark</param>
        /// <returns>Whether or not the board becomes winning as a result of marking the number</returns>
        public bool Mark(int n)
        {
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (_board[i, j] == n)
                    {
                        bool win = Mark(i, j);
                        if (win)
                        {
                            _winningNumber = n;
                        }
                        return win;
                    }
                }
            }
            return false;
        }

        public int CalculateScore()
        {
            int sum = SumUnmarkedNumbers();
            return _winningNumber * sum;
        }

        public void Reset()
        {
            IsWinning = false;
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    _marked[i, j] = false;
                }
            }
        }

        private int SumUnmarkedNumbers()
        {
            int sum = 0;

            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (!_marked[i, j])
                    {
                        sum += _board[i, j];
                    }
                }
            }

            return sum;
        }

        /// <summary>
        /// Mark a number on the bingo board and return true if the board becomes winning as a result.  
        /// </summary>
        /// <param name="row">The row of the number to mark</param>
        /// <param name="col">The column of the number to mark</param>
        /// <returns>Whether or not the board becomes winning as a result of marking the number</returns>
        private bool Mark(int row, int col)
        {
            _marked[row, col] = true;
            return CheckWinning(row, col);
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < BoardSize; i++)
            {
                for (int j = 0; j < BoardSize; j++)
                {
                    if (_marked[i, j])
                    {
                        sb.AppendFormat("({0}) ", _board[i, j]);
                    }
                    else
                    {
                        sb.AppendFormat(" {0}  ", _board[i, j]);
                    }
                }
                sb.AppendFormat("\n");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Check the row, column, and potentially the diagonal that the number is in for a winning combination.
        /// </summary>
        /// <param name="row"></param>
        /// <param name="col"></param>
        /// <returns></returns>
        private bool CheckWinning(int row, int col)
        {
            bool diagWin = false;

            if (row == col) // Number is in a diagonal
            {
                diagWin = CheckDiags();
            }
            IsWinning = diagWin || CheckRow(row) || CheckCol(col);
            return IsWinning;
        }

        private bool CheckRow(int row)
        {
            return Enumerable.Range(0, _marked.GetLength(1))
                .Select(x => _marked[row, x])
                .ToArray()
                .All(x => x);
        }

        private bool CheckCol(int col)
        {
            return Enumerable.Range(0, _marked.GetLength(0))
                .Select(x => _marked[x, col])
                .ToArray()
                .All(x => x);
        }

        private bool CheckDiags()
        {
            bool diag1 = Enumerable.Range(0, BoardSize)
                            .Select(x => _marked[x, x])
                            .ToArray()
                            .All(x => x);

            bool diag2 = Enumerable.Range(0, BoardSize)
                            .Select(x => _marked[x, BoardSize - x - 1])
                            .ToArray()
                            .All(x => x);

            return diag1 || diag2;
        }
    }
}