namespace PolishDraughts;

public class Board
{
    public int Size { get; set; }
    public Dictionary<string, (int,int)> stringPosition = new Dictionary<string, (int,int)>();
    public string allAvailablePositions = "ABCDEFGHIJKLMNOPRST";

    public string[,] CreateBoard(int BoardSize)
    {
        string[,] Board = new string[BoardSize, BoardSize];
        return Board;
    }
    public void CreateAvailablePositions(int size)
    {
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                string firstLetter = allAvailablePositions[column].ToString();
                stringPosition.Add(firstLetter + (row + 1).ToString(), (column, row));
            }
        }
    }
    public (int,int) ToString(string position)
    {
        return stringPosition[position];
    }
}

