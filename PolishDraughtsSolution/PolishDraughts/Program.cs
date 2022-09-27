using PolishDraughts;
Console.WriteLine("Please put size of the board between 10-20: ");
int BoardSize = int.Parse(Console.ReadLine());
Board board = new PolishDraughts.Board();
board.Size = BoardSize;
string[,] CreatedBoard = board.CreateBoard(board.Size);
string[] DisplayBoard = board.DisplayBoard(board.Size);

for (int row = 0; row<BoardSize; row++)
{
    for (int column = 0; column < BoardSize; column++)
    {
        if (row % 2 == 0)
        {
            if (BoardSize % 2 == 0)
            {
                DisplayBoard[row] = string.Concat(Enumerable.Repeat("*** --- ", (BoardSize / 2)));
                DisplayBoard[row] += "\n";
                DisplayBoard[row] += string.Concat(Enumerable.Repeat("* * - - ", (BoardSize / 2)));
                DisplayBoard[row] += "\n";
                DisplayBoard[row] += string.Concat(Enumerable.Repeat("*** --- ", (BoardSize / 2)));
            }
            else
            {
                DisplayBoard[row] = string.Concat(Enumerable.Repeat("*** --- ", (int)(BoardSize / 2)));
                DisplayBoard[row] += "*** \n";
                DisplayBoard[row] += string.Concat(Enumerable.Repeat("* * - - ", (int)(BoardSize / 2)));
                DisplayBoard[row] += "* * \n";
                DisplayBoard[row] += string.Concat(Enumerable.Repeat("*** --- ", (int)(BoardSize / 2)));
                DisplayBoard[row] += "***";
            }
            if (row % 2 == 1)
            {
                if (BoardSize % 2 == 0)
                {
                    DisplayBoard[row] = string.Concat(Enumerable.Repeat("--- *** ", (BoardSize / 2)));
                    DisplayBoard[row] += "\n";
                    DisplayBoard[row] += string.Concat(Enumerable.Repeat("- - * * ", (BoardSize / 2)));
                    DisplayBoard[row] += "\n";
                    DisplayBoard[row] += string.Concat(Enumerable.Repeat("--- *** ", (BoardSize / 2)));
                }
                else
                {
                    DisplayBoard[row] = string.Concat(Enumerable.Repeat("--- *** ", (int)(BoardSize / 2)));
                    DisplayBoard[row] += "--- \n";
                    DisplayBoard[row] += string.Concat(Enumerable.Repeat("- - * * ", (int)(BoardSize / 2)));
                    DisplayBoard[row] += "- - \n";
                    DisplayBoard[row] += string.Concat(Enumerable.Repeat("--- * * ", (int)(BoardSize / 2)));
                    DisplayBoard[row] += "---";
                }
            }
        }
    }
}

for (int row = 0; row < BoardSize; row++)
{
    Console.WriteLine(DisplayBoard[row]);
}