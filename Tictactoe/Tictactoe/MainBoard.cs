using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class MainBoard : Form
    {
        #region Properties
        BoardManager boardManager;
        List<Player> players;
        #endregion

        public MainBoard()
        {
            InitializeComponent();
            
            boardManager = new BoardManager(pnPlayBoard, tbPlayerName, pbMark);
            boardManager.DrawBoard();
        }

        private void btnUpdateInfo_Click(object sender, EventArgs e)
        {
            if (!boardManager.GameRunning())
            {
                var playersInfo = new PlayersInfo(this);
                playersInfo.ShowDialog();

                boardManager.UpdatePlayersInfo(playersInfo.Players);
                playersInfo.Close();
                Enabled = true;         // MainBoard
            }
            btnUpdateInfo.Enabled = false;
        }
    }
}
