using System;
using System.Drawing;

namespace Tictactoe
{
    [Serializable]
    public class NetworkData
    {
        private int command;

        public int Command { get => command; set => command = value; }
        
        private string message;

        public string Message { get => message; set => message = value; }

        private Point location;

        public Point Location { get => location; set => location = value; }

        public enum COMMAND
        {
            CHECKPOINT,
            NOTIFY,
            
            NEWGAME,
            ENDGAME,
            UNDO,
            QUIT
        }

        public NetworkData(int cmd, string msg, Point point)
        {
            Command = cmd;
            Message = msg;
            Location = point;
        }
    }
}
