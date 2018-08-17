using System;
using System.Collections.Generic;
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

            progressBar.Step = Const.PROGRESS_STEP;
            progressBar.Maximum = Const.PROGRESS_MAX;
            progressBar.Value = 0;

            clock.Interval = Const.CLOCK_INTERVAL;

            timeOut = false;

            boardManager = new BoardManager(pnPlayBoard, tbPlayerName, pbMark);
            boardManager.GameStarted += BoardManager_GameStarted;
            boardManager.PlayerThinking += BoardManager_PlayerThinking;
            boardManager.EndedGame += BoardManager_EndedGame;

            boardManager.DrawBoard();
        }

        private void BoardManager_GameStarted(object sender, EventArgs e)
        {
            btnUpdateInfo.Enabled = false;
        }

        private void GameEnd()
        {
            clock.Stop();
            Enabled = false;
            MessageBox.Show(boardManager.WinnerOfTheChicken(timeOut), "GOAL");

            GameReset();
        }

        private void GameReset()
        {
            Enabled = true;
            timeOut = false;
            progressBar.Value = 0;
            boardManager.ResetBoard();
            btnUpdateInfo.Enabled = true;
        }

        private void BoardManager_EndedGame(object sender, EventArgs e)
        {
            GameEnd();
        }

        private void BoardManager_PlayerThinking(object sender, EventArgs e)
        {
            progressBar.Value = 0;
            clock.Start();
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            progressBar.PerformStep();
            lbProgress.Text = "Time: " + progressBar.Value.ToString();

            if (progressBar.Value >= Const.PROGRESS_MAX)
            {
                timeOut = true;
                GameEnd();
            }
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            var playersInfo = new PlayersInfo(this);
            playersInfo.ShowDialog();

            boardManager.UpdatePlayersInfo(playersInfo.Players);
            playersInfo.Close();
            Enabled = true;         // MainBoard
        }
    }
}
