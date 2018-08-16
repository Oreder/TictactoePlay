using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tictactoe
{
    public partial class PlayersInfo : Form
    {
        private MainBoard mainBoard;

        private List<Player> players;

        public List<Player> Players { get => players; set => players = value; }

        public PlayersInfo(MainBoard main)
        {
            InitializeComponent();
            mainBoard = main;
            main.Enabled = false;

            Players = new List<Player>()
            {
                new Player("Player 1", Image.FromFile(Application.StartupPath + "\\Resources\\tac.png")),
                new Player("Player 2", Image.FromFile(Application.StartupPath + "\\Resources\\tic.jpg"))
            };

            openFileDialog.InitialDirectory = Application.StartupPath;
            openFileDialog.Filter = "Pictures (*.png, *.jpg)|*.png; *.jpg";
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Players[0].PlayerName = player01Name.Text;
            Players[0].MarkImage = player01Mark.BackgroundImage;

            Players[1].PlayerName = player02Name.Text;
            Players[1].MarkImage = player02Mark.BackgroundImage;

            Hide();
        }

        private void playerMark_Click(object sender, EventArgs e)
        {
            var markPicture = sender as PictureBox;
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                markPicture.BackgroundImage = Image.FromFile(openFileDialog.FileName);
            }
        }
    }
}
