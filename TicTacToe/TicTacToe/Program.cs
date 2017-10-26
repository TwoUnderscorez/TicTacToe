using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    #region Enums
    public enum TTTMove:byte { X, O, Empty }
    public enum GameStatus:byte { NotInGame, PlayersTurn, PCsTurn, PCWon, PlayerWon, TieGame }
    #endregion
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new MainForm());
            }
            catch (Exception e)
            {
                MessageBox.Show("An unexpected error has occured and not handled properly.\nSorry about that.\n\nPress OK to view the details of the error.", "CRITICAL ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
                DialogResult res = MessageBox.Show(string.Format("{0}\n\nWould you like to copy that to your clipboard?", e.ToString()), "Exception", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
                if(res == DialogResult.Yes)
                    Clipboard.SetDataObject(e.ToString(), true);
                Environment.Exit(0x1);
            }
        }
    }
}
