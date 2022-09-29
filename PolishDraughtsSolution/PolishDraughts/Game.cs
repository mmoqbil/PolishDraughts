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
                    board.CheckPawnByPosition(player);
                    Console.Clear();
                    board.MakeStringBoard();
                    player = "Black";
                }
                else
                {
                    board.CheckPawnByPosition(player);
                    Console.Clear();
                    board.MakeStringBoard();
                    player = "White";
                }
            }
        }
    }
}
