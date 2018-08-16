using System.Windows.Forms;

namespace Tictactoe
{
    public partial class MainBoard : Form
    {
        #region Properties
        BoardManager boardManager;
        #endregion

        public MainBoard()
        {
            InitializeComponent();

            boardManager = new BoardManager(pnPlayBoard);
            boardManager.DrawBoard();
        }
    }
}
