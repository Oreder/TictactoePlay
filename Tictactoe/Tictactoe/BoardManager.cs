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
        private bool isGameStarted;

        /// <summary>
        /// Board view
        /// </summary>
        private List<List<Button>> board;
        public List<List<Button>> Board { get => board; set => board = value; }
        
        /// <summary>
        /// Stack of match steps
        /// </summary>
        private Stack<MatchStep> matchSteps;
        public Stack<MatchStep> MatchSteps { get => matchSteps; set => matchSteps = value; }

        #endregion

        #region Events
        /// <summary>
        /// Player going first is switched? 
        /// </summary>
        private event EventHandler playerSwitched;
        public event EventHandler PlayerSwitched
        {
            add { playerSwitched += value; }
            remove { playerSwitched -= value; }
        }

        /// <summary>
        /// Game starts?
        /// </summary>
        private event EventHandler gameStarted;
        public event EventHandler GameStarted
        {
            add { gameStarted += value; }
            remove { gameStarted -= value; }
        }

        /// <summary>
        /// Current player is thinking?
        /// </summary>
        private event EventHandler<ButtonClickedEventArgs> playerThinking;
        public event EventHandler<ButtonClickedEventArgs> PlayerThinking
        {
            add { playerThinking += value; }
            remove { playerThinking -= value; }
        }

        /// <summary>
        /// Game ends?
        /// </summary>
        private event EventHandler endedGame;
        public event EventHandler EndedGame
        {
            add { endedGame += value; }
            remove { endedGame -= value; }
        }
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
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\tic.jpg")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\tac.png"))
            };

            MatchSteps = new Stack<MatchStep>();

            CurrentPlayerIndex = 0;
            DisplayPlayerInfo();

            isGameStarted = false;
            playerSwitched?.Invoke(this, new EventArgs());
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
        private void Btn_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;

            if (btn.BackgroundImage != null)
                return;
            
            // Display marks on board
            DisplayMarkOnBoard(btn);

            // Save step to stack
            matchSteps.Push(new MatchStep(GetPoint(btn), CurrentPlayerIndex));

            // Switch player
            SwitchPlayer();

            // Display info
            DisplayPlayerInfo();

            // Change status
            if (!isGameStarted)
            {
                isGameStarted = true;
                gameStarted?.Invoke(this, new EventArgs());
            }

            // Checking
            playerThinking?.Invoke(this, new ButtonClickedEventArgs(GetPoint(btn)));

            // Check goal
            if (IsGoal(btn))
                endedGame?.Invoke(this, new EventArgs());
        }

        /// <summary>
        /// For opponent
        /// </summary>
        /// <param name="location"></param>
        public void OpponentPlayerThinking(Point location)
        {
            Button btn = Board[location.Y][location.X];

            if (btn.BackgroundImage != null)
                return;

            // Display marks on board
            DisplayMarkOnBoard(btn);

            // Save step to stack
            matchSteps.Push(new MatchStep(GetPoint(btn), CurrentPlayerIndex));

            // Switch player
            SwitchPlayer();

            // Display info
            DisplayPlayerInfo();

            // Change status
            if (!isGameStarted)
            {
                isGameStarted = true;
                gameStarted?.Invoke(this, new EventArgs());
            }

            // Checking : NO NEED
            //playerThinking?.Invoke(this, new ButtonClickedEventArgs(GetPoint(btn)));

            // Check goal
            if (IsGoal(btn))
                endedGame?.Invoke(this, new EventArgs());
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
        /// Display marks on board
        /// </summary>
        /// <param name="btn"></param>
        private void DisplayMarkOnBoard(Button btn)
        {
            btn.BackgroundImage = Players[CurrentPlayerIndex].MarkImage;
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

        /// <summary>
        /// Update the first going
        /// </summary>
        public void SwitchPlayer()
        {
            CurrentPlayerIndex = 1 - CurrentPlayerIndex;
            DisplayPlayerInfo();
        }

        /// <summary>
        /// Undo command
        /// </summary>
        /// <returns></returns>
        public bool Undo()
        {
            bool result = false;
            if (matchSteps.Count > 0)
            {
                var current = matchSteps.Peek();
                var button = Board[current.Location.Y][current.Location.X];
                button.BackgroundImage = null;

                CurrentPlayerIndex = current.PlayerIndex;
                DisplayPlayerInfo();

                matchSteps.Pop();
                result = true;
            }

            return result;
        }

        public bool UndoLAN()
        {
            if (matchSteps.Count < 2)
                return false;

            Undo();
            Undo();
            return true;
        }
        #endregion

        public string WinnerOfTheChicken(bool timeOut)
        { 
            string msg = Players[1 - CurrentPlayerIndex].PlayerName + " has WON finally!\nScored by: ";
            return msg + (timeOut ? "Opponent ran out of time." : "5 checks in a line first.");
        }

        /// <summary>
        /// Reset board
        /// </summary>
        public void ResetBoard()
        {
            // reset flag
            isGameStarted = false;

            // clear board
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

    /// <summary>
    /// Propose: Get clicked button position through event
    /// </summary>
    public class ButtonClickedEventArgs : EventArgs
    {
        private Point clickedPoint;

        public Point ClickedPoint { get => clickedPoint; set => clickedPoint = value; }

        public ButtonClickedEventArgs(Point point)
        {
            ClickedPoint = point;
        }
    }
}
