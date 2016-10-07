namespace _03_RideTheHorse
{
    public class Cell
    {
        private int row;
        private int col;

        public Cell(int row, int col)
        {
            this.Row = row;
            this.Col = col;
        }

        public int Row
        {
            get
            {
                return row;
            }

            set
            {
                row = value;
            }
        }

        public int Col
        {
            get
            {
                return col;
            }

            set
            {
                col = value;
            }
        }
    }
}
