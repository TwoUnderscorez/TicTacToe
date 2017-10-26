using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public class TTTBox : PictureBox
    {
        private TTTMove _state;

        public TTTMove State
        {
            get { return _state; }
            set
            {
                _state = value;
            }
        }
        public void UpdateImage()
        {
            if (State == TTTMove.O)
                Image = Properties.Resources.O;
            else if (State == TTTMove.X)
                Image = Properties.Resources.X;
            else
                Image = Properties.Resources.Empty;
        }
        public override string ToString()
        {
            return State.ToString();
        }
    }
}
