namespace Tictactoe
{
    partial class MainBoard
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.pnPlayBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.avartaGame = new System.Windows.Forms.PictureBox();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbProgress = new System.Windows.Forms.Label();
            this.btnSwitchPlayer = new System.Windows.Forms.Button();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLAN = new System.Windows.Forms.Button();
            this.pbMark = new System.Windows.Forms.PictureBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.clock = new System.Windows.Forms.Timer(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.gameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newMatchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.avartaGame)).BeginInit();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnPlayBoard
            // 
            this.pnPlayBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnPlayBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPlayBoard.Location = new System.Drawing.Point(0, 28);
            this.pnPlayBoard.Name = "pnPlayBoard";
            this.pnPlayBoard.Size = new System.Drawing.Size(843, 575);
            this.pnPlayBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.BackColor = System.Drawing.Color.Transparent;
            this.panel2.Controls.Add(this.avartaGame);
            this.panel2.Location = new System.Drawing.Point(590, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(249, 243);
            this.panel2.TabIndex = 1;
            // 
            // avartaGame
            // 
            this.avartaGame.BackColor = System.Drawing.Color.Transparent;
            this.avartaGame.BackgroundImage = global::Tictactoe.Properties.Resources.logo;
            this.avartaGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avartaGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avartaGame.Location = new System.Drawing.Point(0, 0);
            this.avartaGame.Name = "avartaGame";
            this.avartaGame.Size = new System.Drawing.Size(249, 243);
            this.avartaGame.TabIndex = 0;
            this.avartaGame.TabStop = false;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.lbProgress);
            this.panel4.Controls.Add(this.btnSwitchPlayer);
            this.panel4.Controls.Add(this.btnUpdateInfo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnLAN);
            this.panel4.Controls.Add(this.pbMark);
            this.panel4.Controls.Add(this.progressBar);
            this.panel4.Controls.Add(this.tbIP);
            this.panel4.Controls.Add(this.tbPlayerName);
            this.panel4.Location = new System.Drawing.Point(590, 252);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(249, 268);
            this.panel4.TabIndex = 2;
            // 
            // lbProgress
            // 
            this.lbProgress.AutoSize = true;
            this.lbProgress.BackColor = System.Drawing.Color.Transparent;
            this.lbProgress.Location = new System.Drawing.Point(3, 136);
            this.lbProgress.Name = "lbProgress";
            this.lbProgress.Size = new System.Drawing.Size(119, 17);
            this.lbProgress.TabIndex = 6;
            this.lbProgress.Text = "Remaining: 15.00";
            // 
            // btnSwitchPlayer
            // 
            this.btnSwitchPlayer.Location = new System.Drawing.Point(146, 163);
            this.btnSwitchPlayer.Name = "btnSwitchPlayer";
            this.btnSwitchPlayer.Size = new System.Drawing.Size(98, 31);
            this.btnSwitchPlayer.TabIndex = 5;
            this.btnSwitchPlayer.Text = "Switch";
            this.btnSwitchPlayer.UseVisualStyleBackColor = true;
            this.btnSwitchPlayer.Click += new System.EventHandler(this.BoardManager_PlayerSwitched);
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Location = new System.Drawing.Point(146, 126);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(98, 36);
            this.btnUpdateInfo.TabIndex = 5;
            this.btnUpdateInfo.Text = "Update info";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(82, 233);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "to win";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(16, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Make 5 in a line";
            // 
            // btnLAN
            // 
            this.btnLAN.Location = new System.Drawing.Point(4, 90);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(136, 30);
            this.btnLAN.TabIndex = 3;
            this.btnLAN.Text = "LAN";
            this.btnLAN.UseVisualStyleBackColor = true;
            this.btnLAN.Click += new System.EventHandler(this.btnLAN_Click);
            // 
            // pbMark
            // 
            this.pbMark.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbMark.BackgroundImage = global::Tictactoe.Properties.Resources.ava;
            this.pbMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMark.Location = new System.Drawing.Point(146, 4);
            this.pbMark.Name = "pbMark";
            this.pbMark.Size = new System.Drawing.Size(98, 116);
            this.pbMark.TabIndex = 2;
            this.pbMark.TabStop = false;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 33);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(136, 23);
            this.progressBar.TabIndex = 1;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(4, 62);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(136, 22);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(4, 4);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.ReadOnly = true;
            this.tbPlayerName.Size = new System.Drawing.Size(136, 22);
            this.tbPlayerName.TabIndex = 0;
            // 
            // clock
            // 
            this.clock.Tick += new System.EventHandler(this.clock_Tick);
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gameToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(843, 28);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // gameToolStripMenuItem
            // 
            this.gameToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newMatchToolStripMenuItem,
            this.undoToolStripMenuItem,
            this.quitToolStripMenuItem});
            this.gameToolStripMenuItem.Name = "gameToolStripMenuItem";
            this.gameToolStripMenuItem.Size = new System.Drawing.Size(60, 24);
            this.gameToolStripMenuItem.Text = "Game";
            // 
            // newMatchToolStripMenuItem
            // 
            this.newMatchToolStripMenuItem.Name = "newMatchToolStripMenuItem";
            this.newMatchToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.R)));
            this.newMatchToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.newMatchToolStripMenuItem.Text = "Restart";
            this.newMatchToolStripMenuItem.Click += new System.EventHandler(this.newMatchToolStripMenuItem_Click);
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // quitToolStripMenuItem
            // 
            this.quitToolStripMenuItem.Name = "quitToolStripMenuItem";
            this.quitToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Alt | System.Windows.Forms.Keys.F4)));
            this.quitToolStripMenuItem.Size = new System.Drawing.Size(181, 26);
            this.quitToolStripMenuItem.Text = "Quit";
            this.quitToolStripMenuItem.Click += new System.EventHandler(this.quitToolStripMenuItem_Click);
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(843, 603);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnPlayBoard);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainBoard";
            this.Text = "Tictactoe";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainBoard_FormClosing);
            this.Shown += new System.EventHandler(this.MainBoard_Shown);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.avartaGame)).EndInit();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pnPlayBoard;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox avartaGame;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Button btnLAN;
        private System.Windows.Forms.PictureBox pbMark;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.TextBox tbIP;
        private System.Windows.Forms.TextBox tbPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnUpdateInfo;
        private System.Windows.Forms.Timer clock;
        private System.Windows.Forms.Button btnSwitchPlayer;
        private System.Windows.Forms.Label lbProgress;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem gameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newMatchToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quitToolStripMenuItem;
    }
}

