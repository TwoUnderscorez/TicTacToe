namespace TicTacToe
{
    partial class OptionsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.parent_gbox = new System.Windows.Forms.GroupBox();
            this.difficulty_slider = new System.Windows.Forms.TrackBar();
            this.label3 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.x_rdbtn = new System.Windows.Forms.RadioButton();
            this.o_rdbtn = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.pc_rdbtn = new System.Windows.Forms.RadioButton();
            this.me_rdbtn = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.close_opts_btn = new System.Windows.Forms.Button();
            this.parent_gbox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty_slider)).BeginInit();
            this.SuspendLayout();
            // 
            // parent_gbox
            // 
            this.parent_gbox.Controls.Add(this.difficulty_slider);
            this.parent_gbox.Controls.Add(this.label3);
            this.parent_gbox.Controls.Add(this.button1);
            this.parent_gbox.Controls.Add(this.x_rdbtn);
            this.parent_gbox.Controls.Add(this.o_rdbtn);
            this.parent_gbox.Controls.Add(this.label2);
            this.parent_gbox.Controls.Add(this.pc_rdbtn);
            this.parent_gbox.Controls.Add(this.me_rdbtn);
            this.parent_gbox.Controls.Add(this.label1);
            this.parent_gbox.Controls.Add(this.close_opts_btn);
            this.parent_gbox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.parent_gbox.Location = new System.Drawing.Point(0, 0);
            this.parent_gbox.Name = "parent_gbox";
            this.parent_gbox.Size = new System.Drawing.Size(170, 184);
            this.parent_gbox.TabIndex = 0;
            this.parent_gbox.TabStop = false;
            this.parent_gbox.Text = "Options";
            // 
            // difficulty_slider
            // 
            this.difficulty_slider.Location = new System.Drawing.Point(7, 104);
            this.difficulty_slider.Maximum = 8;
            this.difficulty_slider.Name = "difficulty_slider";
            this.difficulty_slider.Size = new System.Drawing.Size(157, 45);
            this.difficulty_slider.TabIndex = 9;
            this.difficulty_slider.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.difficulty_HelpRequested);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 88);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Difficulty: ";
            this.label3.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.difficulty_HelpRequested);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(3, 155);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(99, 23);
            this.button1.TabIndex = 7;
            this.button1.Text = "Reset the game";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // x_rdbtn
            // 
            this.x_rdbtn.AutoCheck = false;
            this.x_rdbtn.AutoSize = true;
            this.x_rdbtn.Location = new System.Drawing.Point(55, 68);
            this.x_rdbtn.Name = "x_rdbtn";
            this.x_rdbtn.Size = new System.Drawing.Size(32, 17);
            this.x_rdbtn.TabIndex = 6;
            this.x_rdbtn.Text = "X";
            this.x_rdbtn.UseVisualStyleBackColor = true;
            this.x_rdbtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.sign_HelpRequested);
            this.x_rdbtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.x_rdbtn_MouseClick);
            // 
            // o_rdbtn
            // 
            this.o_rdbtn.AutoCheck = false;
            this.o_rdbtn.AutoSize = true;
            this.o_rdbtn.Checked = true;
            this.o_rdbtn.Location = new System.Drawing.Point(9, 68);
            this.o_rdbtn.Name = "o_rdbtn";
            this.o_rdbtn.Size = new System.Drawing.Size(33, 17);
            this.o_rdbtn.TabIndex = 5;
            this.o_rdbtn.Text = "O";
            this.o_rdbtn.UseVisualStyleBackColor = true;
            this.o_rdbtn.CheckedChanged += new System.EventHandler(this.o_rdbtn_CheckedChanged);
            this.o_rdbtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.sign_HelpRequested);
            this.o_rdbtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.o_rdbtn_MouseClick);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Are you O or X?";
            this.label2.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.sign_HelpRequested);
            // 
            // pc_rdbtn
            // 
            this.pc_rdbtn.AutoCheck = false;
            this.pc_rdbtn.AutoSize = true;
            this.pc_rdbtn.Location = new System.Drawing.Point(55, 32);
            this.pc_rdbtn.Name = "pc_rdbtn";
            this.pc_rdbtn.Size = new System.Drawing.Size(92, 17);
            this.pc_rdbtn.TabIndex = 3;
            this.pc_rdbtn.Text = "The Computer";
            this.pc_rdbtn.UseVisualStyleBackColor = true;
            this.pc_rdbtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.starter_HelpRequested);
            this.pc_rdbtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pc_rdbtn_MouseClick);
            // 
            // me_rdbtn
            // 
            this.me_rdbtn.AutoCheck = false;
            this.me_rdbtn.AutoSize = true;
            this.me_rdbtn.Checked = true;
            this.me_rdbtn.Location = new System.Drawing.Point(9, 32);
            this.me_rdbtn.Name = "me_rdbtn";
            this.me_rdbtn.Size = new System.Drawing.Size(40, 17);
            this.me_rdbtn.TabIndex = 2;
            this.me_rdbtn.TabStop = true;
            this.me_rdbtn.Text = "Me";
            this.me_rdbtn.UseVisualStyleBackColor = true;
            this.me_rdbtn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.starter_HelpRequested);
            this.me_rdbtn.MouseClick += new System.Windows.Forms.MouseEventHandler(this.me_rdbtn_MouseClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Who shall go first?";
            this.label1.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.starter_HelpRequested);
            // 
            // close_opts_btn
            // 
            this.close_opts_btn.Location = new System.Drawing.Point(108, 155);
            this.close_opts_btn.Name = "close_opts_btn";
            this.close_opts_btn.Size = new System.Drawing.Size(56, 23);
            this.close_opts_btn.TabIndex = 0;
            this.close_opts_btn.Text = "Close";
            this.close_opts_btn.UseVisualStyleBackColor = true;
            this.close_opts_btn.Click += new System.EventHandler(this.close_opts_btn_Click);
            this.close_opts_btn.HelpRequested += new System.Windows.Forms.HelpEventHandler(this.close_opts_btn_HelpRequested);
            // 
            // OptionsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.parent_gbox);
            this.Name = "OptionsUserControl";
            this.Size = new System.Drawing.Size(170, 184);
            this.parent_gbox.ResumeLayout(false);
            this.parent_gbox.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.difficulty_slider)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox parent_gbox;
        private System.Windows.Forms.Button close_opts_btn;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton x_rdbtn;
        private System.Windows.Forms.RadioButton o_rdbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RadioButton pc_rdbtn;
        private System.Windows.Forms.RadioButton me_rdbtn;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TrackBar difficulty_slider;
        private System.Windows.Forms.Label label3;
    }
}
