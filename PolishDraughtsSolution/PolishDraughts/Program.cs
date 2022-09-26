//using PolishDraughts;
Console.WriteLine("Please put size of the board between 10-20: ");
int BoardSize = int.Parse(Console.ReadLine());
Console.WriteLine(BoardSize);
PolishDraughts.Board board = new PolishDraughts.Board();
board.Size = BoardSize;
Console.WriteLine(board.Size);
string[,] CreatedBoard = board.CreateBoard(board.Size);
int count = 0;
for (int row = 0; row<BoardSize; row++)
{
    for (int column = 0; column<BoardSize;column++)
    {
        if (row%2==0) 
        {
            if (column % 2 == 1)
            {
                CreatedBoard[row, column] = "B";
            }
            else
            {
                CreatedBoard[row, column] = "W";
            }
        }
        else
        {
            if (column%2 == 0)
            {
                CreatedBoard[row, column] = "B";
            }
            else
            {
                CreatedBoard[row, column] = "W";
            }
        }
        if (count == board.Size-1)
        {
            Console.WriteLine(CreatedBoard[row, column]);
            count = 0;
        }
        else
        {
            Console.Write(CreatedBoard[row, column] + " ");
            count++;
        }

    }
}

