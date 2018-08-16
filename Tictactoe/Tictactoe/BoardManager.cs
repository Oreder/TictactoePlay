using System.Drawing;
using System.Windows.Forms;

namespace Tictactoe
{
    public class BoardManager
    {
        #region Properties
        public Panel BoardPanel { get; set; }
        #endregion

        #region Initialize
        public BoardManager(Panel panel)
        {
            BoardPanel = panel;
        }
        #endregion

        #region Methods
        public void DrawBoard()
        {
            Button oldBtn = new Button() { Width = 0 };
            for (int j = 0; j < Const.TICTAC_BOARD_HEIGHT; ++j)
            {
                for (int i = 0; i < Const.TICTAC_BOARD_WIDTH; ++i)
                {
                    Button btn = GetNextButton(oldBtn);
                    BoardPanel.Controls.Add(btn);
                    oldBtn = btn;
                }

                oldBtn.Location = new Point(0, oldBtn.Location.Y + Const.TICTAC_HEIGHT);
                oldBtn.Width = 0;
            }
        }

        private Button GetNextButton(Button oldBtn) => new Button()
        {
            Width = Const.TICTAC_WIDTH,
            Height = Const.TICTAC_HEIGHT,
            Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y)
        };
        #endregion
    }
}
