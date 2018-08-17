using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Tictactoe
{
    public class BoardManager
    {
        #region Properties
        /// <summary>
        /// Main Board
        /// </summary>
        private Panel boardPanel;
        public Panel BoardPanel { get => boardPanel; set => boardPanel = value; }

        /// <summary>
        /// Player name
        /// </summary>
        private TextBox displayedName;
        public TextBox DisplayedName { get => displayedName; set => displayedName = value; }

        /// <summary>
        /// Player mark
        /// </summary>
        private PictureBox displayedMark;
        public PictureBox DisplayedMark { get => displayedMark; set => displayedMark = value; }

        /// <summary>
        /// List of players
        /// </summary>
        private List<Player> players;
        public List<Player> Players { get => players; set => players = value; }
        
        /// <summary>
        /// Current player index is ZERO if it is the first player, else ONE - the second
        /// </summary>
        private int currentPlayerIndex;
        public int CurrentPlayerIndex { get => currentPlayerIndex; set => currentPlayerIndex = value; }
        
        /// <summary>
        /// Game is now running or not?
        /// </summary>
        private bool gameRunning = false;

        /// <summary>
        /// Board view
        /// </summary>
        private List<List<Button>> board;
        public List<List<Button>> Board { get => board; set => board = value; }

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
            // Initialize board view
            Board = new List<List<Button>>();

            Button oldBtn = new Button() { Width = 0 };
            for (int j = 0; j < Const.TICTAC_BOARD_HEIGHT; ++j)
            {
                // Add a new row
                Board.Add(new List<Button>());

                for (int i = 0; i < Const.TICTAC_BOARD_WIDTH; ++i)
                {
                    Button btn = GetNextButton(oldBtn);
                    btn.Tag = j.ToString();
                    btn.Click += Btn_Click;

                    BoardPanel.Controls.Add(btn);

                    Board[j].Add(btn);

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

            if (btn.BackgroundImage != null)
                return;
            
            // Display marks on board
            DisplayMarkOnBoard(btn);

            // Display info
            DisplayPlayerInfo();

            // Change status
            if (!gameRunning)
                gameRunning = true;

            // Check goal
            if (IsGoal(btn))
            {
                GameEnd();
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

        /// <summary>
        /// EOG
        /// </summary>
        private void GameEnd()
        {
            string msg = Players[currentPlayerIndex].PlayerName + " has WON finally!";
            MessageBox.Show(msg, "GOAL", MessageBoxButtons.OK);

            // Clear all Background
            foreach (var row in Board)
            {
                var filled = from item in row
                             where item.BackgroundImage != null
                             select item;

                foreach (var item in filled)
                    item.BackgroundImage = null;
            }
        }

        #region Check Goal
        /// <summary>
        /// Major goal check
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        private bool IsGoal(Button btn)
        {
            return IsGoalHorizontal(btn) || IsGoalVertical(btn) ||
                IsGoalMajorDiagonal(btn) || IsGoalMinorDiagonal(btn);
        }

        /// <summary>
        /// Get box location 
        /// </summary>
        /// <param name="btn"></param>
        /// <returns></returns>
        private Point GetPoint(Button btn)
        {
            int Y = Convert.ToInt32(btn.Tag);
            int X = Board[Y].IndexOf(btn);

            return new Point(X, Y);
        }

        private bool IsGoalMinorDiagonal(Button btn)
        {
            int count = 0;

            Point current = GetPoint(btn);

            // Left-down
            int i = current.X,
                j = current.Y;
            while (i >= 0 && j < Const.TICTAC_BOARD_HEIGHT &&
                   Board[j++][i--].BackgroundImage == btn.BackgroundImage)
                count++;

            // Right-top
            i = current.X + 1;
            j = current.Y - 1;
            while (i < Const.TICTAC_BOARD_WIDTH && j >= 0 &&
                   Board[j--][i++].BackgroundImage == btn.BackgroundImage)
                count++;

            return count >= 5;
        }

        private bool IsGoalMajorDiagonal(Button btn)
        {
            int count = 0;

            Point current = GetPoint(btn);

            // Upward
            int i = current.X,
                j = current.Y;
            while (i >= 0 && j >= 0 &&
                   Board[j--][i--].BackgroundImage == btn.BackgroundImage)
                count++;

            // Downward
            i = current.X + 1;
            j = current.Y + 1;
            while (i < Const.TICTAC_BOARD_WIDTH &&
                   j < Const.TICTAC_BOARD_HEIGHT &&
                   Board[j++][i++].BackgroundImage == btn.BackgroundImage)
                count++;

            return count >= 5;
        }

        private bool IsGoalVertical(Button btn)
        {
            int count = 0;

            Point current = GetPoint(btn);

            // Let count up first
            int index = current.Y;
            while (index >= 0 && Board[index--][current.X].BackgroundImage == btn.BackgroundImage)
                count++;

            // Now finish by count down
            index = current.Y + 1;
            while (index < Const.TICTAC_BOARD_HEIGHT && Board[index++][current.X].BackgroundImage == btn.BackgroundImage)
                count++;

            return count >= 5;
        }

        private bool IsGoalHorizontal(Button btn)
        {
            int count = 0;

            Point current = GetPoint(btn);

            // Let count left first
            int index = current.X;
            while (index >= 0 && Board[current.Y][index--].BackgroundImage == btn.BackgroundImage)
                count++;

            // Now finish by count right
            index = current.X + 1;
            while (index < Const.TICTAC_BOARD_WIDTH && Board[current.Y][index++].BackgroundImage == btn.BackgroundImage)
                count++;

            return count >= 5;
        }
        #endregion
    }
}
