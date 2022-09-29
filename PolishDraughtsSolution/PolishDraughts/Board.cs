using System.Data.Common;

namespace PolishDraughts;

public class Board
{
    public Dictionary<string, (int x, int y)> stringPosition = new Dictionary<string, (int x, int y)>();
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
        string player = "White";
        while (true)
        {
            if (player == "White")
            {
                CheckPawnByPosition(player);
                Console.Clear();
                MakeStringBoard();
                player = "Black";
            }
            else
            {
                CheckPawnByPosition(player);
                Console.Clear();
                MakeStringBoard();
                player = "White";
            }
        }
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
            if (column <= 8)
            {
                Console.Write("|  " + (column + 1) + "  ");
            }
            else
            {
                Console.Write("|  " + (column + 1) + " ");
            }
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
                    Console.Write("| " + (char)(row + 65) + "  ");

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
                string firstLetter = allAvailablePositions[row].ToString();
                stringPosition.Add(firstLetter + (column + 1).ToString(), (row, column));
            }
        }
    }
    public (int x, int y) ToCoordinates(string position)
    {
        return stringPosition[position];
    }
    public string ToString(int x, int y)
    {
        string result = allAvailablePositions[x].ToString() + (y + 1).ToString();
        return result;
    }
    public Pawn RemovePawn(Pawn pawn)
    {
        pawn = null;
        return pawn;
    }
    public void CheckPawnByPosition(string player)
    {
        Console.WriteLine($"{player}, choose pawn you want to move: ");
        string yourPosition = Console.ReadLine().ToUpper();
        (int x, int y) position = ToCoordinates(yourPosition);
        int x = position.x;
        int y = position.y;
        if (board[x, y] == null)
        {
            Console.WriteLine("This position is empty");
        }
        else
        {

            if (board[x, y].IsWhite == true && player == "White")
            {
                List<string> possibleMoves = new List<string>();
                Console.WriteLine("Possible moves: ");
                if (board[x, y].coordinates.x - 1 > 0 && board[x, y].coordinates.x + 1 < size
                                                      && board[x, y].coordinates.y > 0)
                {
                    if (board[x - 1, y - 1] == null)
                    {
                        (int x, int y) availableMove = board[x, y].coordinates;
                        possibleMoves.Add(ToString(availableMove.x - 1, availableMove.y - 1));
                    }
                    else
                    {
                        if (board[x - 1, y - 1].IsWhite == false && board[x - 2, y - 2] == null)
                        {
                            (int x, int y) availableMove = board[x, y].coordinates;
                            possibleMoves.Add(ToString(availableMove.x - 2, availableMove.y - 2));
                        }
                    }
                }
                if (board[x, y].coordinates.x - 1 > 0 && board[x, y].coordinates.x + 1 < size
                                                      && board[x, y].coordinates.y < size)
                {
                    if (board[x - 1, y + 1] == null)
                    {
                        (int x, int y) availableMove = board[x, y].coordinates;
                        possibleMoves.Add(ToString(availableMove.x - 1, availableMove.y + 1));
                    }
                    else
                    {
                        if (board[x - 1, y + 1].IsWhite == false && board[x - 2, y + 2] == null)
                        {
                            (int x, int y) availableMove = board[x, y].coordinates;
                            possibleMoves.Add(ToString(availableMove.x - 2, availableMove.y + 2));
                        }
                    }
                }
                foreach (string move in possibleMoves)
                {
                    Console.Write(move + " ");
                }
                yourPosition = Console.ReadLine().ToUpper();
                while (!possibleMoves.Contains(yourPosition))
                {
                    Console.WriteLine("Wrong move. Try another one");
                    yourPosition = Console.ReadLine();
                }
                (int x, int y) newPosition = ToCoordinates(yourPosition);
                newPosition = (newPosition.x, newPosition.y);
                board[x, y].MovePawn(newPosition);
                int new_x = newPosition.x;
                int new_y = newPosition.y;
                if (x - new_x == 2)
                {
                    if (new_y - y == 2)
                    {
                        Console.WriteLine("Pozycja do zbicia = " + (new_x + 1) + "," + (new_y - 1));
                        board[new_x + 1, new_y - 1] = RemovePawn(board[new_x + 1, new_y - 1]);
                        Console.ReadLine();
                    }
                    else if(y - new_y == 2)
                    {
                        Console.WriteLine("Pozycja do zbicia = " + (new_x + 1) + "," + (new_y + 1));
                        board[new_x + 1, new_y + 1] = RemovePawn(board[new_x + 1, new_y + 1]);
                        Console.ReadLine();
                    }
                }
                board[new_x, new_y] = board[x, y];
                board[x,y] = RemovePawn(board[x,y]);


            }
            else if (board[x, y].IsWhite == false && player == "Black")
            {
                List<string> possibleMoves = new List<string>();
                Console.WriteLine("Possible moves: ");
                if (board[x, y].coordinates.x - 1 > 0 && board[x, y].coordinates.x + 1 < size
                                                      && board[x, y].coordinates.y > 0)
                {
                    if (board[x + 1, y - 1] == null)
                    {
                        (int x, int y) availableMove = board[x, y].coordinates;
                        possibleMoves.Add(ToString(availableMove.x + 1, availableMove.y - 1));
                    }
                    else
                    {
                        if (board[x + 1, y - 1].IsWhite == true && board[x + 2, y - 2] == null)
                        {
                            (int x, int y) availableMove = board[x, y].coordinates;
                            possibleMoves.Add(ToString(availableMove.x + 2, availableMove.y - 2));
                        }
                    }
                }
                if (board[x, y].coordinates.x - 1 > 0 && board[x, y].coordinates.x + 1 < size
                                                      && board[x, y].coordinates.y < size)
                {
                    if (board[x + 1, y + 1] == null)
                    {
                        (int x, int y) availableMove = board[x, y].coordinates;
                        possibleMoves.Add(ToString(availableMove.x + 1, availableMove.y + 1));
                    }
                    else
                    {
                        if (board[x + 1, y + 1].IsWhite == true && board[x + 2, y + 2] == null)
                        {
                            (int x, int y) availableMove = board[x, y].coordinates;
                            possibleMoves.Add(ToString(availableMove.x + 2, availableMove.y + 2));
                        }
                    }
                }
                foreach (string move in possibleMoves)
                {
                    Console.Write(move + " ");
                }
                yourPosition = Console.ReadLine().ToUpper();
                while (!possibleMoves.Contains(yourPosition))
                {
                    Console.WriteLine("Wrong move. Try another one");
                    yourPosition = Console.ReadLine();
                }
                (int x, int y) newPosition = ToCoordinates(yourPosition);
                newPosition = (newPosition.x, newPosition.y);
                Console.WriteLine(board[x, y].coordinates.x + "," + board[x, y].coordinates.y);
                Console.WriteLine(newPosition);
                board[x, y].MovePawn(newPosition);
                int new_x = newPosition.x;
                int new_y = newPosition.y;
                if (new_x - x == 2)
                {
                    if (new_y - y == 2)
                    {
                        Console.WriteLine("Pozycja do zbicia = " + (new_x - 1) + "," + (new_y - 1));
                        board[new_x - 1, new_y - 1] = RemovePawn(board[new_x - 1, new_y - 1]);
                        Console.ReadLine();
                    }
                    else if (y - new_y == 2)
                    {
                        Console.WriteLine("Pozycja do zbicia = " + (new_x - 1) + "," + (new_y + 1));
                        board[new_x - 1, new_y + 1] = RemovePawn(board[new_x - 1, new_y + 1]);
                        Console.ReadLine();
                    }
                }
                board[new_x, new_y] = board[x, y];
                board[x, y] = null;
                Console.ReadLine();
            }
        }
    }
}