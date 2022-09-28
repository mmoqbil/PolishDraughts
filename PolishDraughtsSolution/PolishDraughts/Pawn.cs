namespace PolishDraughts
{
    public class Pawn
    {
        private bool isWhite;
        public bool IsWhite
        {
            get { return isWhite; }
            set { isWhite = value; }
        }

        public (int,int) coordinates { get; set; }

        public Pawn(bool _isWhite, int row, int column)
        {
            coordinates = (column, row);
            isWhite = _isWhite;
        }
        public void MovePawn((int,int) pawnPosition)
        {
            coordinates = pawnPosition;
        }
    }

}