using PolishDraughts;

Console.WriteLine("Please put size of the board between 10-20: ");
int BoardSize = int.Parse(Console.ReadLine());
Board board = new Board();
board.Size = BoardSize;
string[,] CreatedBoard = board.CreateBoard(board.Size);
string[] OneDBoard = board.OneDBoard(board.Size);
string[] DisplayBoard = board.DisplayBoard(OneDBoard, BoardSize);
board.ShowBoard(DisplayBoard,BoardSize);

