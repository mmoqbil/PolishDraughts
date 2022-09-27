namespace PolishDraughts;

public class Board
{
    public int Size { get; set; }

    public string[,] TwoDBoard(int BoardSize)
    {
        string[,] Board = new string[BoardSize, BoardSize];
        return Board;
    }

    public string[] OneDBoard(int BoardSize)
    {
        string[] Board = new string[BoardSize];
        return Board;
    }

    public string[] MakeStringsBoard(string[] OneDBoard, int BoardSize, string[,] BoardWithPawns)
    {

        for (int row = 0; row < BoardSize; row++)
        {
            for (int column = 0; column < BoardSize; column++)
            {
                if (row % 2 == 0)
                {
                    if (BoardSize % 2 == 0)
                    {
                        OneDBoard[row] = string.Concat(Enumerable.Repeat("*** --- ", (BoardSize / 2)));
                        OneDBoard[row] += "\n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat($"*{BoardWithPawns[row, column]}* -{BoardWithPawns[row, column]}- ", (BoardSize / 2)));
                        OneDBoard[row] += "\n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("*** --- ", (BoardSize / 2)));
                    }
                    else
                    {
                        OneDBoard[row] = string.Concat(Enumerable.Repeat("*** --- ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "*** \n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat($"*{BoardWithPawns[row, column]}* -{BoardWithPawns[row, column]}- ", (int)(BoardSize / 2)));
                        OneDBoard[row] += $"*{BoardWithPawns[row, column]}* \n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("*** --- ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "***";
                    }
                }

                if (row % 2 == 1)
                {
                    if (BoardSize % 2 == 0)
                    {
                        OneDBoard[row] = string.Concat(Enumerable.Repeat("--- *** ", (BoardSize / 2)));
                        OneDBoard[row] += "\n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat($"-{BoardWithPawns[row, column]}- *{BoardWithPawns[row, column]}* ", (BoardSize / 2)));
                        OneDBoard[row] += "\n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("--- *** ", (BoardSize / 2)));
                    }
                    else
                    {
                        OneDBoard[row] = string.Concat(Enumerable.Repeat("--- *** ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "--- \n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat($"-{BoardWithPawns[row, column]}- *{BoardWithPawns[row, column]}* ", (int)(BoardSize / 2)));
                        OneDBoard[row] += $"-{BoardWithPawns[row, column]}- \n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("--- *** ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "---";
                    }
                }
            }
        }

        return OneDBoard;
    }
    public void ShowBoard(string[] DisplayBoard, int BoardSize)
    {
        for (int row = 0; row < BoardSize; row++)
        {
            Console.WriteLine(DisplayBoard[row]);
        }
        
    }

    public string[,] PutPawnsOnBoard(string[,] EmptyBoard,int BoardSize)
    {
        for (int row = 0; row < BoardSize; row++)
        {
            for (int column = 0; column < BoardSize; column++)
            {
                if (row == BoardSize - 1 )
                { 
                    if (column % 2 == 1)
                    {                     
                        EmptyBoard[row, column] = "W";                              
                    }
                }
                else if (row == BoardSize - 2)
                {
                    if (column % 2 == 0)
                    {
                        EmptyBoard[row, column] = "W";
                    }
                }
                else if (row == 0)
                {
                    if (column % 2 == 0)
                    {
                        EmptyBoard[row, column] = "B";
                    }
                }
                else if (row == 1)
                {
                    if (column % 2 == 1)
                    {
                        EmptyBoard[row, column] = "B";
                    }
                }
                else
                {
                    EmptyBoard[row, column] = " ";
                }
            }
        }
        return EmptyBoard;
    }
}
