namespace PolishDraughts
{
    public class Pawn 
    {
        private bool isWhite;
        private bool disposed = false;
        public bool IsWhite
        {
            get { return isWhite; }
            set { isWhite = value; }
        }

        public (int x, int y) coordinates { get; set; }

        public Pawn(bool _isWhite, int row, int column)
        {
            coordinates = (row, column);
            isWhite = _isWhite;
        }
        public void MovePawn((int, int) pawnPosition)
        {
            coordinates = pawnPosition;
        }
    }
}