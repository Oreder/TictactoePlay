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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainBoard));
            this.pnPlayBoard = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.btnLAN = new System.Windows.Forms.Button();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.tbIP = new System.Windows.Forms.TextBox();
            this.tbPlayerName = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnUpdateInfo = new System.Windows.Forms.Button();
            this.pbMark = new System.Windows.Forms.PictureBox();
            this.avartaGame = new System.Windows.Forms.PictureBox();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.avartaGame)).BeginInit();
            this.SuspendLayout();
            // 
            // pnPlayBoard
            // 
            this.pnPlayBoard.BackColor = System.Drawing.SystemColors.Control;
            this.pnPlayBoard.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnPlayBoard.Location = new System.Drawing.Point(0, 0);
            this.pnPlayBoard.Name = "pnPlayBoard";
            this.pnPlayBoard.Size = new System.Drawing.Size(812, 553);
            this.pnPlayBoard.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.avartaGame);
            this.panel2.Location = new System.Drawing.Point(579, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(229, 223);
            this.panel2.TabIndex = 1;
            // 
            // panel4
            // 
            this.panel4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.panel4.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.panel4.Controls.Add(this.btnUpdateInfo);
            this.panel4.Controls.Add(this.label1);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Controls.Add(this.btnLAN);
            this.panel4.Controls.Add(this.pbMark);
            this.panel4.Controls.Add(this.progressBar);
            this.panel4.Controls.Add(this.tbIP);
            this.panel4.Controls.Add(this.tbPlayerName);
            this.panel4.Location = new System.Drawing.Point(579, 232);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(229, 234);
            this.panel4.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(7, 170);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(214, 30);
            this.label2.TabIndex = 4;
            this.label2.Text = "Make 5 in a line";
            // 
            // btnLAN
            // 
            this.btnLAN.Location = new System.Drawing.Point(4, 90);
            this.btnLAN.Name = "btnLAN";
            this.btnLAN.Size = new System.Drawing.Size(113, 30);
            this.btnLAN.TabIndex = 3;
            this.btnLAN.Text = "LAN";
            this.btnLAN.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(4, 33);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(113, 23);
            this.progressBar.TabIndex = 1;
            // 
            // tbIP
            // 
            this.tbIP.Location = new System.Drawing.Point(4, 62);
            this.tbIP.Name = "tbIP";
            this.tbIP.Size = new System.Drawing.Size(113, 22);
            this.tbIP.TabIndex = 0;
            this.tbIP.Text = "127.0.0.1";
            // 
            // tbPlayerName
            // 
            this.tbPlayerName.Location = new System.Drawing.Point(4, 4);
            this.tbPlayerName.Name = "tbPlayerName";
            this.tbPlayerName.ReadOnly = true;
            this.tbPlayerName.Size = new System.Drawing.Size(113, 22);
            this.tbPlayerName.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 16.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(73, 200);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(90, 30);
            this.label1.TabIndex = 4;
            this.label1.Text = "to win";
            // 
            // btnUpdateInfo
            // 
            this.btnUpdateInfo.Location = new System.Drawing.Point(123, 126);
            this.btnUpdateInfo.Name = "btnUpdateInfo";
            this.btnUpdateInfo.Size = new System.Drawing.Size(98, 31);
            this.btnUpdateInfo.TabIndex = 5;
            this.btnUpdateInfo.Text = "Update info";
            this.btnUpdateInfo.UseVisualStyleBackColor = true;
            this.btnUpdateInfo.Click += new System.EventHandler(this.btnUpdateInfo_Click);
            // 
            // pbMark
            // 
            this.pbMark.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.pbMark.BackgroundImage = global::Tictactoe.Properties.Resources.ava;
            this.pbMark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbMark.Location = new System.Drawing.Point(123, 4);
            this.pbMark.Name = "pbMark";
            this.pbMark.Size = new System.Drawing.Size(98, 116);
            this.pbMark.TabIndex = 2;
            this.pbMark.TabStop = false;
            // 
            // avartaGame
            // 
            this.avartaGame.BackColor = System.Drawing.Color.Transparent;
            this.avartaGame.BackgroundImage = global::Tictactoe.Properties.Resources.logo;
            this.avartaGame.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.avartaGame.Dock = System.Windows.Forms.DockStyle.Fill;
            this.avartaGame.Location = new System.Drawing.Point(0, 0);
            this.avartaGame.Name = "avartaGame";
            this.avartaGame.Size = new System.Drawing.Size(229, 223);
            this.avartaGame.TabIndex = 0;
            this.avartaGame.TabStop = false;
            // 
            // MainBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 553);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pnPlayBoard);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainBoard";
            this.Text = "Tictactoe";
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbMark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.avartaGame)).EndInit();
            this.ResumeLayout(false);

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
    }
}

