using System.Drawing;

namespace Tictactoe
{
    public class MatchStep
    {
        private Point location;

        public Point Location { get => location; set => location = value; }
        
        private int playerIndex;

        public int PlayerIndex { get => playerIndex; set => playerIndex = value; }

        public MatchStep(Point point, int index)
        {
            Location = point;
            playerIndex = index;
        }
    }
}
