using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class MainBoard : Form
    {
        #region Properties

        private BoardManager boardManager;
        private bool timeOut;
        private SocketManager networkManager;

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
            boardManager.PlayerSwitched += BoardManager_PlayerSwitched;
            boardManager.PlayerThinking += BoardManager_PlayerThinking;
            boardManager.EndedGame += BoardManager_EndedGame;

            boardManager.DrawBoard();

            networkManager = new SocketManager();
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

        #region Update player's info
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            var playersInfo = new PlayersInfo(this, boardManager.Players);
            playersInfo.ShowDialog();

            boardManager.UpdatePlayersInfo(playersInfo.Players);
            playersInfo.Close();
            Enabled = true;         // MainBoard
        }
        #endregion

        #region Quit and Restart
        /// <summary>
        /// Restart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newMatchToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Enabled = false;
            clock.Stop();

            if (MessageBox.Show("Are you sure to restart match?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
                GameReset();
            else
                clock.Start();

            Enabled = true;
        }

        /// <summary>
        /// Quit game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainBoard_FormClosing(object sender, FormClosingEventArgs e)
        {
            clock.Stop();
            if (MessageBox.Show("Are you sure to quit game?", "Warning", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop) != DialogResult.OK)
            {
                e.Cancel = true;
                clock.Start();
            }
        }

        private void quitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion

        #region Undo
        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            clock.Stop();
            if (!boardManager.Undo())
                MessageBox.Show("No step to undo now! Go ahead.", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Hand);

            progressBar.Value = 0;
            clock.Start();
        }
        #endregion

        private void MainBoard_Shown(object sender, EventArgs e)
        {
            tbIP.Text = networkManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbIP.Text))
                tbIP.Text = networkManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            // Config IP
            networkManager.IP = tbIP.Text;

            // Server is not created!
            if (!networkManager.ConnectToServer())
            {
                networkManager.CreateServer();

                // if client sent data, server must listen always
                var listenThread = new Thread(() =>
                {
                    // Pause 0.5s to try listen from clients
                    Thread.Sleep(500);

                    while (true)
                    {
                        // Server tries to listen every moment, 
                        // until get receipt-pack from client
                        try { Listen(); break; }
                        catch { }
                    }
                })
                {
                    IsBackground = true
                };
                listenThread.Start();
            }
            else    // Server has been ready!
            {
                var listenThread = new Thread(() =>
                {
                    Listen();
                })
                {
                    IsBackground = true
                };
                listenThread.Start();

                networkManager.Send("Tictactoe LAN");
            }
        }

        private void Listen()
        {
            string data = (string)networkManager.Receive();
            MessageBox.Show(data);
        }
    }
}
