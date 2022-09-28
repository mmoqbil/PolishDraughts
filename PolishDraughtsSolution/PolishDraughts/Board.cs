namespace PolishDraughts;

public class Board
{
    public Dictionary<string, (int,int)> stringPosition = new Dictionary<string, (int,int)>();
    public string allAvailablePositions = "ABCDEFGHIJKLMNOPRST";
    private Pawn[,] _board;
    private int size;

    public Pawn[,] board
    {
        get { return _board; }
    }

    public int Size
    {
        get { return size; }
        set
        {
            if ((value >= 10) && (value <= 20))
            {
                size = value;
            }
        }
    }

    public Board()
    {
        List<int> allowedSize = new List<int>() { 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20 };

        while (!allowedSize.Contains(size))
        {
            Console.WriteLine("Please input the size of the board (10-20): ");
            size = int.Parse(Console.ReadLine());
        }
        _board = new Pawn[size, size];
        CreateBoard();
        Console.WriteLine(MakeStringBoard());
        CreateAvailablePositions(size);
        Console.WriteLine(ToString("A2"));
    }

    public void CreateBoard()
    {
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                List<int> allowedRows = new List<int>() { 0, 1, 2, 3, size - 1, size - 2, size - 3, size - 4 };
                if (allowedRows.Contains(row))
                {
                    if (row % 2 == 0)
                    {
                        if (column % 2 == 0)
                        {
                            if (row > size / 2)
                                board[row, column] = new Pawn(true, row, column);
                            else
                                board[row, column] = new Pawn(false, row, column);
                        }
                        else
                            board[row, column] = null;
                    }
                    else
                    {
                        if (column % 2 == 1)
                        {
                            if (row > size / 2)
                                board[row, column] = new Pawn(true, row, column);
                            else
                                board[row, column] = new Pawn(false, row, column);
                        }
                        else
                            board[row, column] = null;
                    }

                }
            }
        }
    }
    public string MakeStringBoard()
    {
        int n = ((size + 1) * 6 - 2);

        for (int k = 0; k <= n; k++)
        {
            Console.Write('-');
        }
        Console.WriteLine("-");

        Console.Write("|    ");
        for (int column = 0; column <= (size - 1); column++)
        {
            Console.Write("|  " + (char)(column + 65) + "  ");
        }
        Console.WriteLine("|");

        for (int k = 0; k <= n; k++)
        {
            Console.Write('-');
        }
        Console.WriteLine("-");

        for (int row = 0; row <= (size - 1); row++)
        {
            for (int l = 0; l <= 2; l++)
            {
                if (l % 2 == 1)
                {
                    if (row <= 8)
                    {
                        Console.Write("| " + (row + 1) + "  ");
                    }
                    else
                    {
                        Console.Write("| " + (row + 1) + " ");
                    }
                    for (int column = 0; column <= (size - 1); column++)
                    {
                        if (board[row, column] == null)
                        {
                            if ((row % 2 == 1 & column % 2 == 0) | (row % 2 == 0 & column % 2 == 1))
                            {
                                Console.Write("|*****");
                            }
                            else
                            {
                                Console.Write("|     ");
                            }
                        }
                        else
                        {
                            if (board[row, column].IsWhite == false)
                            {
                                Console.Write("|  B  ");
                            }
                            else
                            {
                                Console.Write("|  W  ");
                            }
                        }
                    }
                    Console.WriteLine("|");
                }
                else
                {
                    Console.Write("|    ");
                    for (int column = 0; column <= (size - 1); column++) 
                        if ((row % 2 == 1 & column % 2 == 0) | (row % 2 == 0 & column % 2 == 1))
                        {
                            Console.Write("|*****");
                        }
                        else
                        {
                            Console.Write("|     ");
                        }
                    Console.WriteLine("|");
                }
            }
            for (int k = 0; k <= n; k++)
            {
                Console.Write('-');
            }
            Console.WriteLine('-');
        }
        return "-";
    }
    public void CreateAvailablePositions(int size)
    {
        for (int row = 0; row < size; row++)
        {
            for (int column = 0; column < size; column++)
            {
                string firstLetter = allAvailablePositions[column].ToString();
                stringPosition.Add(firstLetter + (row + 1).ToString(), (row, column));
            }
        }
    }
    public (int,int) ToString(string position)
    {
        return stringPosition[position];
    }
}

