namespace PolishDraughts
{
    public class Game
    {
        Board board = new Board();
        public void Start()
        {
            Console.WriteLine("Welcome, this is Polish Draughts. White Pawns starts!");
            Round();
        }       
        public void Round()
        {
            string player = "White";
            while (true)
            {
                if (player == "White")
                {
                    TryToMakeMove(player);
                    Console.Clear();
                    board.MakeStringBoard();
                    player = "Black";
                }
                else
                {
                    TryToMakeMove(player);
                    Console.Clear();
                    board.MakeStringBoard();
                    player = "White";
                }
            }
        }
        public void TryToMakeMove(string player)
        {
            Console.WriteLine($"{player}, choose pawn you want to move: ");
            string yourPosition = Console.ReadLine().ToUpper();
            (int x, int y) position = board.ToCoordinates(yourPosition);
            int x = position.x;
            int y = position.y;
            if (board.board[x, y] == null)
            {
                Console.WriteLine("This position is empty");
            }
            else
            {

                if (board.board[x, y].IsWhite == true && player == "White")
                {
                    List<string> possibleMoves = new List<string>();
                    Console.WriteLine("Possible moves: ");
                    if (board.board[x, y].coordinates.x - 1 > 0 && board.board[x, y].coordinates.x + 1 < board.Size
                                                          && board.board[x, y].coordinates.y > 0)
                    {
                        if (board.board[x - 1, y - 1] == null)
                        {
                            (int x, int y) availableMove = board.board[x, y].coordinates;
                            possibleMoves.Add(board.ToString(availableMove.x - 1, availableMove.y - 1));
                        }
                        else
                        {
                            if (board.board[x - 1, y - 1].IsWhite == false && board.board[x - 2, y - 2] == null)
                            {
                                (int x, int y) availableMove = board.board[x, y].coordinates;
                                possibleMoves.Add(board.ToString(availableMove.x - 2, availableMove.y - 2));
                            }
                        }
                    }
                    if (board.board[x, y].coordinates.x - 1 > 0 && board.board[x, y].coordinates.x + 1 < board.Size
                                                          && board.board[x, y].coordinates.y < board.Size)
                    {
                        if (board.board[x - 1, y + 1] == null)
                        {
                            (int x, int y) availableMove = board.board[x, y].coordinates;
                            possibleMoves.Add(board.ToString(availableMove.x - 1, availableMove.y + 1));
                        }
                        else
                        {
                            if (board.board[x - 1, y + 1].IsWhite == false && board.board[x - 2, y + 2] == null)
                            {
                                (int x, int y) availableMove = board.board[x, y].coordinates;
                                possibleMoves.Add(board.ToString(availableMove.x - 2, availableMove.y + 2));
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
                    (int x, int y) newPosition = board.ToCoordinates(yourPosition);
                    newPosition = (newPosition.x, newPosition.y);
                    board.board[x, y] = board.MovePawn(newPosition, board.board[x, y]);
                    int new_x = newPosition.x;
                    int new_y = newPosition.y;
                    if (x - new_x == 2)
                    {
                        if (new_y - y == 2)
                        {
                            Console.WriteLine("Pozycja do zbicia = " + (new_x + 1) + "," + (new_y - 1));
                            board.board[new_x + 1, new_y - 1] = board.RemovePawn(board.board[new_x + 1, new_y - 1]);
                            Console.ReadLine();
                        }
                        else if (y - new_y == 2)
                        {
                            Console.WriteLine("Pozycja do zbicia = " + (new_x + 1) + "," + (new_y + 1));
                            board.board[new_x + 1, new_y + 1] = board.RemovePawn(board.board[new_x + 1, new_y + 1]);
                            Console.ReadLine();
                        }
                    }
                    board.board[new_x, new_y] = board.board[x, y];
                    board.board[x, y] = board.RemovePawn(board.board[x, y]);


                }
                else if (board.board[x, y].IsWhite == false && player == "Black")
                {
                    List<string> possibleMoves = new List<string>();
                    Console.WriteLine("Possible moves: ");
                    if (board.board[x, y].coordinates.x - 1 > 0 && board.board[x, y].coordinates.x + 1 < board.Size
                                                          && board.board[x, y].coordinates.y > 0)
                    {
                        if (board.board[x + 1, y - 1] == null)
                        {
                            (int x, int y) availableMove = board.board[x, y].coordinates;
                            possibleMoves.Add(board.ToString(availableMove.x + 1, availableMove.y - 1));
                        }
                        else
                        {
                            if (board.board[x + 1, y - 1].IsWhite == true && board.board[x + 2, y - 2] == null)
                            {
                                (int x, int y) availableMove = board.board[x, y].coordinates;
                                possibleMoves.Add(board.ToString(availableMove.x + 2, availableMove.y - 2));
                            }
                        }
                    }
                    if (board.board[x, y].coordinates.x - 1 > 0 && board.board[x, y].coordinates.x + 1 < board.Size
                                                          && board.board[x, y].coordinates.y < board.Size)
                    {
                        if (board.board[x + 1, y + 1] == null)
                        {
                            (int x, int y) availableMove = board.board[x, y].coordinates;
                            possibleMoves.Add(board.ToString(availableMove.x + 1, availableMove.y + 1));
                        }
                        else
                        {
                            if (board.board[x + 1, y + 1].IsWhite == true && board.board[x + 2, y + 2] == null)
                            {
                                (int x, int y) availableMove = board.board[x, y].coordinates;
                                possibleMoves.Add(board.ToString(availableMove.x + 2, availableMove.y + 2));
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
                    (int x, int y) newPosition = board.ToCoordinates(yourPosition);
                    newPosition = (newPosition.x, newPosition.y);
                    Console.WriteLine(board.board[x, y].coordinates.x + "," + board.board[x, y].coordinates.y);
                    Console.WriteLine(newPosition);
                    board.board[x, y] = board.MovePawn(newPosition, board.board[x, y]);
                    int new_x = newPosition.x;
                    int new_y = newPosition.y;
                    if (new_x - x == 2)
                    {
                        if (new_y - y == 2)
                        {
                            Console.WriteLine("Pozycja do zbicia = " + (new_x - 1) + "," + (new_y - 1));
                            board.board[new_x - 1, new_y - 1] = board.RemovePawn(board.board[new_x - 1, new_y - 1]);
                            Console.ReadLine();
                        }
                        else if (y - new_y == 2)
                        {
                            Console.WriteLine("Pozycja do zbicia = " + (new_x - 1) + "," + (new_y + 1));
                            board.board[new_x - 1, new_y + 1] = board.RemovePawn(board.board[new_x - 1, new_y + 1]);
                            Console.ReadLine();
                        }
                    }
                    board.board[new_x, new_y] = board.board[x, y];
                    board.board[x, y] = board.RemovePawn(board.board[x, y]);
                    Console.ReadLine();
                }
            }
        }
    }
}
