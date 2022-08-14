namespace Sharpshooter_PraviinPremsankar
{
	partial class GameForm
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

		#region Windows Form Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameForm));
            this.GameTimer = new System.Windows.Forms.Timer(this.components);
            this.MainMenu = new System.Windows.Forms.MenuStrip();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.resetToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pauseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.TitlePic = new System.Windows.Forms.PictureBox();
            this.PlayLabel = new System.Windows.Forms.Label();
            this.Pause = new System.Windows.Forms.Label();
            this.onePlayer = new System.Windows.Forms.Label();
            this.twoPlayer = new System.Windows.Forms.Label();
            this.MainMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePic)).BeginInit();
            this.SuspendLayout();
            // 
            // GameTimer
            // 
            this.GameTimer.Interval = 50;
            this.GameTimer.Tick += new System.EventHandler(this.GameTimer_Tick);
            // 
            // MainMenu
            // 
            this.MainMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.optionsToolStripMenuItem});
            this.MainMenu.Location = new System.Drawing.Point(0, 0);
            this.MainMenu.Name = "MainMenu";
            this.MainMenu.Size = new System.Drawing.Size(784, 24);
            this.MainMenu.TabIndex = 0;
            this.MainMenu.Text = "menuStrip1";
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.resetToolStripMenuItem,
            this.exitToolStripMenuItem,
            this.pauseToolStripMenuItem});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // resetToolStripMenuItem
            // 
            this.resetToolStripMenuItem.Name = "resetToolStripMenuItem";
            this.resetToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F1;
            this.resetToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.resetToolStripMenuItem.Text = "Reset";
            this.resetToolStripMenuItem.Click += new System.EventHandler(this.resetToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // pauseToolStripMenuItem
            // 
            this.pauseToolStripMenuItem.Name = "pauseToolStripMenuItem";
            this.pauseToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F3;
            this.pauseToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.pauseToolStripMenuItem.Text = "Pause";
            this.pauseToolStripMenuItem.Click += new System.EventHandler(this.pauseToolStripMenuItem_Click);
            // 
            // TitlePic
            // 
            this.TitlePic.Image = ((System.Drawing.Image)(resources.GetObject("TitlePic.Image")));
            this.TitlePic.Location = new System.Drawing.Point(85, 74);
            this.TitlePic.Name = "TitlePic";
            this.TitlePic.Size = new System.Drawing.Size(594, 196);
            this.TitlePic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;
            this.TitlePic.TabIndex = 1;
            this.TitlePic.TabStop = false;
            // 
            // PlayLabel
            // 
            this.PlayLabel.AutoSize = true;
            this.PlayLabel.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PlayLabel.ForeColor = System.Drawing.Color.OrangeRed;
            this.PlayLabel.Location = new System.Drawing.Point(26, 432);
            this.PlayLabel.Name = "PlayLabel";
            this.PlayLabel.Size = new System.Drawing.Size(116, 61);
            this.PlayLabel.TabIndex = 2;
            this.PlayLabel.Text = "Play";
            this.PlayLabel.Visible = false;
            this.PlayLabel.Click += new System.EventHandler(this.PlayLabel_Click);
            // 
            // Pause
            // 
            this.Pause.AutoSize = true;
            this.Pause.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Pause.ForeColor = System.Drawing.Color.OrangeRed;
            this.Pause.Location = new System.Drawing.Point(302, 291);
            this.Pause.Name = "Pause";
            this.Pause.Size = new System.Drawing.Size(154, 61);
            this.Pause.TabIndex = 4;
            this.Pause.Text = "Pause";
            this.Pause.Visible = false;
            // 
            // onePlayer
            // 
            this.onePlayer.AutoSize = true;
            this.onePlayer.BackColor = System.Drawing.Color.Black;
            this.onePlayer.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.onePlayer.ForeColor = System.Drawing.Color.OrangeRed;
            this.onePlayer.Location = new System.Drawing.Point(279, 260);
            this.onePlayer.Name = "onePlayer";
            this.onePlayer.Size = new System.Drawing.Size(198, 61);
            this.onePlayer.TabIndex = 5;
            this.onePlayer.Text = "1 Player";
            this.onePlayer.Click += new System.EventHandler(this.onePlayer_Click);
            // 
            // twoPlayer
            // 
            this.twoPlayer.AutoSize = true;
            this.twoPlayer.Font = new System.Drawing.Font("Franklin Gothic Medium", 36F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Italic | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.twoPlayer.ForeColor = System.Drawing.Color.OrangeRed;
            this.twoPlayer.Location = new System.Drawing.Point(279, 363);
            this.twoPlayer.Name = "twoPlayer";
            this.twoPlayer.Size = new System.Drawing.Size(198, 61);
            this.twoPlayer.TabIndex = 6;
            this.twoPlayer.Text = "2 Player";
            this.twoPlayer.Click += new System.EventHandler(this.twoPlayer_Click);
            // 
            // GameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(784, 581);
            this.Controls.Add(this.twoPlayer);
            this.Controls.Add(this.onePlayer);
            this.Controls.Add(this.Pause);
            this.Controls.Add(this.PlayLabel);
            this.Controls.Add(this.TitlePic);
            this.Controls.Add(this.MainMenu);
            this.MainMenuStrip = this.MainMenu;
            this.Name = "GameForm";
            this.Text = "Sharpshooter";
            this.MainMenu.ResumeLayout(false);
            this.MainMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TitlePic)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

        #endregion

        private System.Windows.Forms.Timer GameTimer;
        private System.Windows.Forms.MenuStrip MainMenu;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem resetToolStripMenuItem;
        private System.Windows.Forms.PictureBox TitlePic;
        private System.Windows.Forms.Label PlayLabel;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pauseToolStripMenuItem;
        private System.Windows.Forms.Label Pause;
        private System.Windows.Forms.Label onePlayer;
        private System.Windows.Forms.Label twoPlayer;
    }
}

