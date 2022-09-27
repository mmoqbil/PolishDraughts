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
    public (int,int) ToString(string position, int size)
    {
        for (int row = 0;row < size;row++)
        {
            for (int column = 0;column<size;column++)
            {
                string firstLetter = allAvailablePositions[column].ToString();
                stringPosition.Add(firstLetter + (row+1).ToString(),(column,row));
            }
        }
        foreach (KeyValuePair<string, (int, int)> entry in stringPosition)
        {
            Console.Write(entry.Key);
            Console.Write(entry.Value);
        }
        return stringPosition[position];
    }
}

