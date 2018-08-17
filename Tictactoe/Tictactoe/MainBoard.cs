using System;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class MainBoard : Form
    {
        #region Properties
        BoardManager boardManager;
        bool timeOut;
        #endregion

        public MainBoard()
        {
            InitializeComponent();

            //progressBar = new ProgressBarConfig();
            progressBar.Step = Const.PROGRESS_STEP;
            progressBar.Maximum = Const.PROGRESS_MAX;
            progressBar.Value = 0;

            clock.Interval = Const.CLOCK_INTERVAL;

            timeOut = false;

            boardManager = new BoardManager(pnPlayBoard, tbPlayerName, pbMark);
            boardManager.GameStarted += BoardManager_GameStarted;
            boardManager.PlayerSwitched += BoardManager_PlayerSwitched;
            boardManager.PlayerThinking += BoardManager_PlayerThinking;
            boardManager.EndedGame += BoardManager_EndedGame;

            boardManager.DrawBoard();
        }
        
        #region Event: GameStarted
        private void BoardManager_GameStarted(object sender, EventArgs e)
        {
            btnUpdateInfo.Enabled = false;
            btnSwitchPlayer.Enabled = false;
        }
        #endregion

        #region Event: PlayerSwitched
        private void BoardManager_PlayerSwitched(object sender, EventArgs e)
        {
            boardManager.SwitchPlayer();
        }
        #endregion

        #region Event: PlayerThinking
        private void BoardManager_PlayerThinking(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            clock.Start();
        }
        #endregion

        #region Event: GameEnd
        /// <summary>
        /// What to do when game ends
        /// </summary>
        private void GameEnd()
        {
            clock.Stop();
            Enabled = false;    // Main board
            MessageBox.Show(boardManager.WinnerOfTheChicken(timeOut), "GOAL");

            GameReset();
        }

        /// <summary>
        /// Reset new game
        /// </summary>
        private void GameReset()
        {
            Enabled = true;     // Main board
            timeOut = false;
            progressBar.Value = 0;
            boardManager.ResetBoard();

            btnUpdateInfo.Enabled = true;
            btnSwitchPlayer.Enabled = true;
        }

        private void BoardManager_EndedGame(object sender, EventArgs e)
        {
            GameEnd();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            progressBar.PerformStep();
            lbProgress.Text = "Remaining: " + string.Format("{0:F2}", (Const.PROGRESS_MAX - progressBar.Value) / 1000.0);

            if (progressBar.Value >= Const.PROGRESS_MAX)
            {
                timeOut = true;
                GameEnd();
            }
        }
        #endregion

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            var playersInfo = new PlayersInfo(this, boardManager.Players);
            playersInfo.ShowDialog();

            boardManager.UpdatePlayersInfo(playersInfo.Players);
            playersInfo.Close();
            Enabled = true;         // MainBoard
        }
    }
}
