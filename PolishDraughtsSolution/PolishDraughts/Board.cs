namespace PolishDraughts;

public class Board
{
    public int Size { get; set; }

    public string[,] CreateBoard(int BoardSize)
    {
        string[,] Board = new string[BoardSize, BoardSize];
        return Board;
    }

    public string[] OneDBoard(int BoardSize)
    {
        string[] Board = new string[BoardSize];
        return Board;
    }

    public string[] DisplayBoard(string[] OneDBoard, int BoardSize)
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
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("* * - - ", (BoardSize / 2)));
                        OneDBoard[row] += "\n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("*** --- ", (BoardSize / 2)));
                    }
                    else
                    {
                        OneDBoard[row] = string.Concat(Enumerable.Repeat("*** --- ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "*** \n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("* * - - ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "* * \n";
                        OneDBoard[row] += string.Concat(Enumerable.Repeat("*** --- ", (int)(BoardSize / 2)));
                        OneDBoard[row] += "***";
                    }
                    if (row % 2 == 1)
                    {
                        if (BoardSize % 2 == 0)
                        {
                            OneDBoard[row] = string.Concat(Enumerable.Repeat("--- *** ", (BoardSize / 2)));
                            OneDBoard[row] += "\n";
                            OneDBoard[row] += string.Concat(Enumerable.Repeat("- - * * ", (BoardSize / 2)));
                            OneDBoard[row] += "\n";
                            OneDBoard[row] += string.Concat(Enumerable.Repeat("--- *** ", (BoardSize / 2)));
                        }
                        else
                        {
                            OneDBoard[row] = string.Concat(Enumerable.Repeat("--- *** ", (int)(BoardSize / 2)));
                            OneDBoard[row] += "--- \n";
                            OneDBoard[row] += string.Concat(Enumerable.Repeat("- - * * ", (int)(BoardSize / 2)));
                            OneDBoard[row] += "- - \n";
                            OneDBoard[row] += string.Concat(Enumerable.Repeat("--- * * ", (int)(BoardSize / 2)));
                            OneDBoard[row] += "---";
                        }
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
}

    