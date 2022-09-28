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

        public Tuple<int, int> coordinates { get; set; }

        public Pawn(bool _isWhite, int row, int column)
        {
            coordinates = Tuple.Create(row, column);
            isWhite = _isWhite;
        }
    }

}