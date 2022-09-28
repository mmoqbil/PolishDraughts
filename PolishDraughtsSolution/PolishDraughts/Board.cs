namespace PolishDraughts;

public class Board
{
    public Dictionary<string, (int x,int y)> stringPosition = new Dictionary<string, (int x,int y)>();
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
        Console.WriteLine(ToString(0, 2));
        Console.WriteLine(ToCoordinates("B6"));
        CheckPawnByPosition();
        CheckPawnByPosition();
        CheckPawnByPosition();
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
                string firstLetter = allAvailablePositions[row].ToString();
                stringPosition.Add(firstLetter + (column + 1).ToString(), (row, column));
            }
        }
    }
    public (int x,int y) ToCoordinates(string position)
    {
        return stringPosition[position];
    }
    public string ToString(int x, int y)
    {
        string result = allAvailablePositions[x].ToString() + (y+1).ToString();
        return result;
    }
    public void CheckPawnByPosition()
    {
        Console.WriteLine("Write your position on board: ");
        string yourPosition = Console.ReadLine();
        (int, int) position = ToCoordinates(yourPosition);
        Console.WriteLine(position);
        int x = position.Item1;
        int y = position.Item2;
        Console.WriteLine(x);
        Console.WriteLine(y);
        if(board[y,x] == null)
        {
            Console.WriteLine("This position is empty");
        }
        else
        {
            
            if (board[y, x].IsWhite == true)
            {
                List<string> possibleMoves = new List<string>();
                Console.WriteLine("There is a  White Pawn here, Where do you want to move it?");
                Console.WriteLine("To tutaj");
                Console.WriteLine(ToString(board[x, y].coordinates.Item1, board[x, y].coordinates.Item2));
                Console.WriteLine("Possible moves: ");
                if (board[y, x].coordinates.Item1 - 1 > 0 && board[y,x].coordinates.Item1 + 1 < size
                    && board[y,x].coordinates.Item2 - 1 > 0)
                {
                    if (board[y - 1, x - 1] == null)
                    {
                        (int x, int y) availableMove = board[x, y].coordinates;
                        Console.WriteLine(ToString(availableMove.x, availableMove.y-1));
                        Console.Write(availableMove.x + "," + availableMove.y);
                        possibleMoves.Add(ToString(availableMove.x - 1, availableMove.y-1));
                    }

                    if (board[y - 1, x + 1] == null)
                    {
                        (int x, int y) availableMove = board[x, y].coordinates;
                        Console.WriteLine(ToString(availableMove.x, availableMove.y-1));
                        Console.Write(availableMove.x + "," + availableMove.y);
                        possibleMoves.Add(ToString(availableMove.x + 1, availableMove.y-1));
                    }
                    Console.WriteLine("To tutaj");
                    Console.WriteLine(ToString(board[x,y].coordinates.Item1,board[x,y].coordinates.Item2));
                }
                    foreach(string move in possibleMoves)
                {
                    Console.Write(move + " ");
                }
                    Console.WriteLine(board[x, y].coordinates);
                    yourPosition = Console.ReadLine();
                    while(!possibleMoves.Contains(yourPosition))
                {
                    Console.WriteLine("Wrong move. Try another one");
                    yourPosition = Console.ReadLine();
                }
                (int x, int y) newPosition = ToCoordinates(yourPosition);
                    Console.WriteLine(newPosition);
                newPosition = (newPosition.y, newPosition.x);
                Console.WriteLine(newPosition);
                Console.WriteLine(board[x, y].coordinates);
                Console.WriteLine(ToString(newPosition.x,newPosition.y));
                    board[x, y].MovePawn(newPosition);
                Console.WriteLine(board[x, y].coordinates);
                    int new_x = newPosition.x;
                    int new_y = newPosition.y;
                    board[new_x, new_y] = board[y, x];
                Console.WriteLine("NOWA POZYCJA (B6 - (1,5)");
                Console.Write(newPosition.x);
                Console.Write(newPosition.y);
                Console.WriteLine(board[new_x, new_y].coordinates);
                    board[y, x] = null;
                    MakeStringBoard();
                
            }
            else
            {
                Console.WriteLine("There is a Black Pawn here");
                Console.WriteLine("To tutaj");
                Console.WriteLine(ToString(board[x, y].coordinates.Item1, board[x, y].coordinates.Item2));
                Console.Write(board[x, y].coordinates.Item1 + "," + board[x, y].coordinates.Item2);
                yourPosition = Console.ReadLine();
                (int, int) newPosition = ToCoordinates(yourPosition);
                board[x, y].MovePawn(newPosition);
                int new_x = newPosition.Item1;
                int new_y = newPosition.Item2;
                board[new_x, new_y] = board[x, y];
                board[x, y] = null;
                MakeStringBoard();
            }
        }
    }
}

