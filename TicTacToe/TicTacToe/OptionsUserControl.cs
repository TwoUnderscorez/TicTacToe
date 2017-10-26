using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicTacToe
{
    public partial class OptionsUserControl : UserControl
    {
        MainForm parent;
        public OptionsUserControl(MainForm parent)
        {
            InitializeComponent();
            this.parent = parent;
        }
        private void starter_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Here can you set who goes first.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void sign_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Here you can set as whom you would like to play as.", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private void difficulty_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Here you can set the difficulty of the computer. (The higher the difficulty the more time it might take for the computer to calculate it's move).", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        private async void close_opts_btn_Click(object sender, EventArgs e)
        {
            EnableControls(false);
            parent.Enabled = false;
            do
            {
                Top -= 4;
                await Task.Delay(1);
            } while (Top > -Height);
            SaveSettings();
            parent.Enabled = true;
            parent.EnableControls(true);
        }

        public void EnableControls(bool enable)
        {
            close_opts_btn.Enabled = enable;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void x_rdbtn_MouseClick(object sender, MouseEventArgs e)
        {
            o_rdbtn.Checked = false;
            x_rdbtn.Checked = true;
        }

        private void o_rdbtn_MouseClick(object sender, MouseEventArgs e)
        {
            o_rdbtn.Checked = true;
            x_rdbtn.Checked = false;
        }

        private void pc_rdbtn_MouseClick(object sender, MouseEventArgs e)
        {
            me_rdbtn.Checked = false;
            pc_rdbtn.Checked = true;
        }

        private void me_rdbtn_MouseClick(object sender, MouseEventArgs e)
        {
            me_rdbtn.Checked = true;
            pc_rdbtn.Checked = false;
        }

        public void LoadSettings()
        {
            if (Properties.Settings.Default.playerO) o_rdbtn_MouseClick(null, null);
            else x_rdbtn_MouseClick(null, null);
            if (Properties.Settings.Default.playerFirst) me_rdbtn_MouseClick(null, null);
            else pc_rdbtn_MouseClick(null, null);
            difficulty_slider.Value = Properties.Settings.Default.difficulty;
        }
        private void SaveSettings()
        {
            Properties.Settings.Default.playerFirst = me_rdbtn.Checked;
            Properties.Settings.Default.playerO = o_rdbtn.Checked;
            Properties.Settings.Default.difficulty = difficulty_slider.Value;
            Properties.Settings.Default.Save();
        }

        private void o_rdbtn_CheckedChanged(object sender, EventArgs e)
        {
            foreach(TTTBox box in parent.TTTBoxes)
            {
                if (box.State == TTTMove.O)
                {
                    box.State = TTTMove.X;
                    box.Image = Properties.Resources.X;
                }
                else if(box.State == TTTMove.X)
                {
                    box.State = TTTMove.O;
                    box.Image = Properties.Resources.O;
                }
            }
        }

        private void close_opts_btn_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            MessageBox.Show("Saves the settings and closes the options dialog", "Help", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
