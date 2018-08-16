using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Tictactoe
{
    public class BoardManager
    {
        #region Properties
        private Panel boardPanel;

        public Panel BoardPanel { get => boardPanel; set => boardPanel = value; }

        private TextBox displayedName;

        public TextBox DisplayedName { get => displayedName; set => displayedName = value; }

        private PictureBox displayedMark;

        public PictureBox DisplayedMark { get => displayedMark; set => displayedMark = value; }

        private List<Player> players;

        public List<Player> Players { get => players; set => players = value; }
        
        private int currentPlayerIndex;

        public int CurrentPlayerIndex { get => currentPlayerIndex; set => currentPlayerIndex = value; }
        
        private bool gameRunning = false;

        #endregion

        #region Initialize
        public BoardManager(Panel panel, TextBox textBox, PictureBox pictureBox)
        {
            BoardPanel = panel;
            DisplayedName = textBox;
            DisplayedMark = pictureBox;
            DisplayedMark.BackgroundImageLayout = ImageLayout.Stretch;

            Players = new List<Player>()
            {
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\tac.png")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\tic.jpg"))
            };

            currentPlayerIndex = 0;
            DisplayPlayerInfo();
        }
        #endregion

        #region Methods
        /// <summary>
        /// Display grid-board
        /// </summary>
        public void DrawBoard()
        {
            Button oldBtn = new Button() { Width = 0 };
            for (int j = 0; j < Const.TICTAC_BOARD_HEIGHT; ++j)
            {
                for (int i = 0; i < Const.TICTAC_BOARD_WIDTH; ++i)
                {
                    Button btn = GetNextButton(oldBtn);

                    btn.Click += Btn_Click;

                    BoardPanel.Controls.Add(btn);

                    oldBtn = btn;
                }

                oldBtn.Location = new Point(0, oldBtn.Location.Y + Const.TICTAC_HEIGHT);
                oldBtn.Width = 0;
            }
        }

        /// <summary>
        /// Event for each players
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, System.EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.BackgroundImage == null)
            {
                // Display marks on board
                DisplayMarkOnBoard(btn);

                // Display info
                DisplayPlayerInfo();

                // Change status
                if (!gameRunning)
                    gameRunning = true;
            }
        }

        /// <summary>
        /// Create board square by previous box
        /// </summary>
        /// <param name="oldBtn"></param>
        /// <returns></returns>
        private Button GetNextButton(Button oldBtn) => new Button()
        {
            Width = Const.TICTAC_WIDTH,
            Height = Const.TICTAC_HEIGHT,
            Location = new Point(oldBtn.Location.X + oldBtn.Width, oldBtn.Location.Y),
            BackgroundImageLayout = ImageLayout.Stretch
        };

        /// <summary>
        /// Check game-running's status
        /// </summary>
        /// <returns></returns>
        public bool GameRunning() => gameRunning;

        /// <summary>
        /// Display marks on board
        /// </summary>
        /// <param name="btn"></param>
        private void DisplayMarkOnBoard(Button btn)
        {
            btn.BackgroundImage = Players[CurrentPlayerIndex].MarkImage;
            CurrentPlayerIndex = (CurrentPlayerIndex == 0) ? 1 : 0;
        }

        /// <summary>
        /// Display current player's information
        /// </summary>
        private void DisplayPlayerInfo()
        {
            DisplayedName.Text = Players[CurrentPlayerIndex].PlayerName;
            DisplayedMark.BackgroundImage = Players[CurrentPlayerIndex].MarkImage;
        }

        /// <summary>
        /// Apply for updating players' information
        /// </summary>
        /// <param name="players"></param>
        public void UpdatePlayersInfo(List<Player> players)
        {
            Players = players;
            DisplayPlayerInfo();
        }
        #endregion
    }
}
