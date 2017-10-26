namespace TicTacToe
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Extra GUI code
        /// <summary>
        /// Here goes complex GUI code
        /// </summary>
        private void InitializeCustomComponent()
        {
            this.TTTBoxes = new TTTBox[3, 3];
            this.root_table.SuspendLayout();
            this.SuspendLayout();

            //Options
            this.optsUsrCtrl = new OptionsUserControl(this);
            this.optsUsrCtrl.Location = new System.Drawing.Point(
                this.Width / 2 - optsUsrCtrl.Width / 2, -optsUsrCtrl.Height);
            this.Controls.Add(optsUsrCtrl);
            this.optsUsrCtrl.BringToFront();

            // Tic Tac Toe boxes
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                {
                    TTTBox pb = new TTTBox();
                    pb.Dock = System.Windows.Forms.DockStyle.Fill;
                    pb.Image = Properties.Resources.Empty;
                    pb.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                    pb.State = TTTMove.Empty;
                    pb.Tag = string.Format("{0}{1}", i, j);
                    pb.MouseClick += this.TTTBox_Press;
                    pb.HelpRequested += this.TTTBox_HelpRequested;
                    TTTBoxes[i, j] = pb;
                    this.root_table.Controls.Add(pb, i, j);
                }
            
            this.root_table.ResumeLayout(false);
            this.ResumeLayout(false);
        }
        public void EnableControls(bool enable)
        {
            opt_btn.Enabled = enable;
            play_btn.Enabled = enable;
            foreach (TTTBox box in TTTBoxes)
                box.Enabled = enable;
        }
        #endregion

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.root_table = new System.Windows.Forms.TableLayoutPanel();
            this.exit_btn = new System.Windows.Forms.Button();
            this.play_btn = new System.Windows.Forms.Button();
            this.opt_btn = new System.Windows.Forms.Button();
            this.root_table.SuspendLayout();
            this.SuspendLayout();
            // 
            // root_table
            // 
            this.root_table.ColumnCount = 3;
            this.root_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.root_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.root_table.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.root_table.Controls.Add(this.exit_btn, 0, 3);
            this.root_table.Controls.Add(this.play_btn, 2, 3);
            this.root_table.Controls.Add(this.opt_btn, 1, 3);
            this.root_table.Dock = System.Windows.Forms.DockStyle.Fill;
            this.root_table.Location = new System.Drawing.Point(0, 0);
            this.root_table.Name = "root_table";
            this.root_table.RowCount = 4;
            this.root_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.root_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.root_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.root_table.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.root_table.Size = new System.Drawing.Size(337, 287);
            this.root_table.TabIndex = 0;
            // 
            // exit_btn
            // 
            this.exit_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.exit_btn.Location = new System.Drawing.Point(3, 258);
            this.exit_btn.Name = "exit_btn";
            this.exit_btn.Size = new System.Drawing.Size(106, 26);
            this.exit_btn.TabIndex = 0;
            this.exit_btn.Text = "Exit";
            this.exit_btn.UseVisualStyleBackColor = true;
            this.exit_btn.Click += new System.EventHandler(this.exit_btn_Click);
            this.exit_btn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.exit_btn_HelpRequested);
            // 
            // play_btn
            // 
            this.play_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.play_btn.Location = new System.Drawing.Point(227, 258);
            this.play_btn.Name = "play_btn";
            this.play_btn.Size = new System.Drawing.Size(107, 26);
            this.play_btn.TabIndex = 1;
            this.play_btn.Text = "Play";
            this.play_btn.UseVisualStyleBackColor = true;
            this.play_btn.Click += new System.EventHandler(this.play_btn_Click);
            this.play_btn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.play_btn_HelpRequested);
            // 
            // opt_btn
            // 
            this.opt_btn.Dock = System.Windows.Forms.DockStyle.Fill;
            this.opt_btn.Location = new System.Drawing.Point(115, 258);
            this.opt_btn.Name = "opt_btn";
            this.opt_btn.Size = new System.Drawing.Size(106, 26);
            this.opt_btn.TabIndex = 2;
            this.opt_btn.Text = "Options";
            this.opt_btn.UseVisualStyleBackColor = true;
            this.opt_btn.Click += new System.EventHandler(this.opt_btn_Click);
            this.opt_btn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.opt_btn_HelpRequested);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(337, 287);
            this.Controls.Add(this.root_table);
            this.HelpButton = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(353, 326);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Tic Tac Toe";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Resize += new System.EventHandler(this.MainForm_Resize);
            this.root_table.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel root_table;
        private System.Windows.Forms.Button exit_btn;
        private System.Windows.Forms.Button play_btn;
        private System.Windows.Forms.Button opt_btn;
        public TTTBox[,] TTTBoxes;
        private OptionsUserControl optsUsrCtrl;
    }
}

