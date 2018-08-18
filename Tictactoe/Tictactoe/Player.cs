using System.Drawing;

namespace Tictactoe
{
    public class Player
    {
        #region Properties
        /// <summary>
        /// Player's name
        /// </summary>
        private string playerName;
        public string PlayerName { get => playerName; set => playerName = value; }
        
        /// <summary>
        /// Player's mark
        /// </summary>
        private Image markImage;
        public Image MarkImage { get => markImage; set => markImage = value; }

        #endregion

        public Player(string name, Image mark)
        {
            PlayerName = name;
            MarkImage = mark;
        }
    }
}
