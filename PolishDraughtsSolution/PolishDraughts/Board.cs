namespace PolishDraughts;

public class Board
{
    public int Size { get; set; }

    public string[,] CreateBoard(int BoardSize)
    {
        string[,] Board = new string[BoardSize, BoardSize];
        return Board;
    }
}

