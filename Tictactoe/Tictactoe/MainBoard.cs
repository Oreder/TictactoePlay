using System;
using System.Net.NetworkInformation;
using System.Threading;
using System.Windows.Forms;
using static Tictactoe.NetworkData;

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

            // avoid change interface when using multi-thread
            CheckForIllegalCrossThreadCalls = false;

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
        private void SwitchPlayer(bool boardFlag)
        {
            boardManager.SwitchPlayer();
            pnPlayBoard.Enabled = boardFlag;
        }

        private void BoardManager_PlayerSwitched(object sender, EventArgs e)
        {
            SwitchPlayer(true);
            networkManager.Send(new NetworkData((int)COMMAND.SWITCHPLAYER));
        }
        #endregion

        #region Event: PlayerThinking
        private void BoardManager_PlayerThinking(object sender, ButtonClickedEventArgs e)
        {
            btnSwitchPlayer.Enabled = false;
            progressBar.Value = 0;
            pnPlayBoard.Enabled = false;
            clock.Start();

            networkManager.Send(new NetworkData((int)COMMAND.CHECKPOINT, null, e.ClickedPoint));
            undoToolStripMenuItem.Enabled = false;
            Listen();
        }
        #endregion

        #region Event: GameEnd
        /// <summary>
        /// What to do when game ends
        /// </summary>
        private void GameEnd()
        {
            clock.Stop();
            pnPlayBoard.Enabled = false;    // Main board
            MessageBox.Show(boardManager.WinnerOfTheChicken(timeOut), "GOAL");

            GameReset();
        }

        /// <summary>
        /// Reset new game
        /// </summary>
        private void GameReset()
        {
            timeOut = false;
            progressBar.Value = 0;
            boardManager.ResetBoard();

            btnUpdateInfo.Enabled = true;
            btnSwitchPlayer.Enabled = true;
        }

        private void BoardManager_EndedGame(object sender, EventArgs e)
        {
            GameEnd();
            pnPlayBoard.Enabled = false;
            networkManager.Send(new NetworkData((int)COMMAND.ENDGAME));
        }

        private void clock_Tick(object sender, EventArgs e)
        {
            progressBar.PerformStep();
            lbProgress.Text = "Remaining: " + string.Format("{0:F2}", (Const.PROGRESS_MAX - progressBar.Value) / 1000.0);

            if (progressBar.Value >= Const.PROGRESS_MAX)
            {
                timeOut = true;
                BoardManager_EndedGame(sender, e);
            }
        }
        #endregion

        #region Update player's info
        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            var playersInfo = new PlayersInfo(this, boardManager.Players);
            playersInfo.ShowDialog();

            boardManager.UpdatePlayersInfo(playersInfo.Players);
            networkManager.Send(new NetworkData((int)COMMAND.UPDATEINFO));
            //TODO: send updated info

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
            clock.Stop();

            if (MessageBox.Show("Are you sure to restart match?", "Warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                pnPlayBoard.Enabled = false;
                GameReset();
                networkManager.Send(new NetworkData((int)COMMAND.NEWGAME));
                pnPlayBoard.Enabled = true;
            }
            else
            {
                clock.Start();
            }
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
            else
            {
                try
                {
                    networkManager.Send(new NetworkData((int)COMMAND.QUIT));
                    pnPlayBoard.Enabled = true;
                }
                catch { }
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
            if (!boardManager.UndoLAN())
                MessageBox.Show("No step to undo now! Go ahead.", "Error 404", MessageBoxButtons.OK, MessageBoxIcon.Hand);
            else
            {
                progressBar.Value = 0;
                networkManager.Send(new NetworkData((int)COMMAND.UNDO));
            }
            clock.Start();
        }
        #endregion

        #region LAN Connection
        /// <summary>
        /// Show local IPv4
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MainBoard_Shown(object sender, EventArgs e)
        {
            tbIP.Text = networkManager.GetLocalIPv4(NetworkInterfaceType.Wireless80211);
            if (string.IsNullOrEmpty(tbIP.Text))
                tbIP.Text = networkManager.GetLocalIPv4(NetworkInterfaceType.Ethernet);
        }

        private void btnLAN_Click(object sender, EventArgs e)
        {
            // Fix bugs
            btnUpdateInfo.Enabled = false;
            
            // TODO: set same players' info

            // Config IP
            networkManager.IP = tbIP.Text;

            // Server is not created!
            if (!networkManager.ConnectToServer())
            {
                // SERVER
                networkManager.CreateServer();
                pnPlayBoard.Enabled = true;
            }
            else    // Server has been ready!
            {
                // CLIENTS
                pnPlayBoard.Enabled = false;
                Listen();
            }
        }

        private void Listen()
        {
            var listenThread = new Thread(() =>
                {
                    try
                    {
                        var data = (NetworkData)networkManager.Receive();
                        ProcessData(data);
                    }
                    catch { }
                })
            {
                IsBackground = true
            };
            listenThread.Start();
        }

        private void ProcessData(NetworkData data)
        {
            switch (data.Command)
            {
                case (int)COMMAND.NOTIFY:
                    MessageBox.Show(data.Message, "Notification");
                    break;

                case (int)COMMAND.CHECKPOINT:
                    Invoke((MethodInvoker)(() =>
                    {
                        progressBar.Value = 0;
                        pnPlayBoard.Enabled = true;
                        clock.Start();
                        boardManager.OpponentPlayerThinking(data.Location);
                        undoToolStripMenuItem.Enabled = true;
                    }));
                    break;

                case (int)COMMAND.UPDATEINFO:
                    // TODO: update info
                    break;

                case (int)COMMAND.SWITCHPLAYER:
                    Invoke((MethodInvoker)(() =>
                    {
                        SwitchPlayer(false);
                    }));
                    break;

                case (int)COMMAND.ENDGAME:
                    Invoke((MethodInvoker)(() =>
                    {
                        GameReset();
                        pnPlayBoard.Enabled = true;
                    }));
                    break;

                case (int)COMMAND.NEWGAME:
                    Invoke((MethodInvoker)(() =>
                    {
                        clock.Stop();
                        GameReset();
                        pnPlayBoard.Enabled = false;
                    }));
                    break;

                case (int)COMMAND.UNDO:
                    boardManager.UndoLAN();
                    progressBar.Value = 0;
                    break;

                case (int)COMMAND.QUIT:
                    clock.Stop();
                    MessageBox.Show("Your opponent exit the game.", "Notification");

                    GameReset();
                    pnPlayBoard.Enabled = true;
                    break;

                default:
                    break;
            }

            Listen();
        }
        #endregion
    }
}
