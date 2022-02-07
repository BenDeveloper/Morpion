namespace Morpion.BoardGame
{
    public class Game
    {
        public int[,] Grid { get; set; }

        public Game()
        {
            this.Initialization();
        }

        public void Initialization()
        {
            Grid = new int[3,3]
            {
                {0, 0, 0},
                {0, 0, 0},
                {0, 0, 0}
            };
        }

        public void SetValue(int x, int y, GridEnumValue value)
        {
            int position = Grid[x, y];

            if (position != 0)
            {
                throw new PositionAlreadyPlayedException();
            }

            Grid[x, y] = (int)value;
        }

        public bool Won(GridEnumValue value)
        {
            // Horizontal
            for (int i=0; i < 3; i++)
            {
                if (Grid[i, 0] == (int)value &&
                    Grid[i, 1] == (int)value &&
                    Grid[i, 2] == (int)value)
                {
                    return true;
                }
            }

            // Vertical
            for (int i = 0; i < 3; i++)
            {
                if (Grid[0, i] == (int)value &&
                    Grid[1, i] == (int)value &&
                    Grid[2, i] == (int)value)
                {
                    return true;
                }
            }

            // Diagonal
            for (int i = 0; i < 3; i++)
            {
                if ((Grid[0, 0] == (int)value &&
                    Grid[1, 1] == (int)value &&
                    Grid[2, 2] == (int)value) ||
                    (Grid[0, 2] == (int)value &&
                    Grid[1, 1] == (int)value &&
                    Grid[2, 0] == (int)value))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
