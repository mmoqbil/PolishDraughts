using PolishDraughts;

Console.WriteLine("Please put size of the board between 10-20: ");
int BoardSize = int.Parse(Console.ReadLine());
Board board = new Board();
board.Size = BoardSize;
string[,] BoardForPawns = board.TwoDBoard(board.Size);
string[] OneDBoard = board.OneDBoard(board.Size);
string[,] BoardWithPawns = board.PutPawnsOnBoard(BoardForPawns, BoardSize);
string[] MakeStringsBoard = board.MakeStringsBoard(OneDBoard, BoardSize, BoardWithPawns);
board.ShowBoard(MakeStringsBoard, BoardSize);

