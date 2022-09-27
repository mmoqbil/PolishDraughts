namespace PolishDraughts;

public class Board
{
    public int Size { get; set; }
    public enum pos_x
    {
        A = 0,
        B = 1,
        C = 2,
        D = 3,
        E = 4,
        F = 5,
        G = 6,
        H = 7,
        I = 8,
        J = 9,
        K = 10,
        L = 11,
        M = 12,
        N = 13,
        O = 14,
        P = 15,
        Q = 16,
        R = 17,
        S = 18,
        T = 19,
    }

    public string[,] CreateBoard(int BoardSize)
    {
        string[,] Board = new string[BoardSize, BoardSize];
        return Board;
    }
    public void ToString(string position)
    {
        
        int x_pos = 0;
        foreach (var val in Enum.GetValues(typeof(pos_x)))
        {
        
        }
    }
}

