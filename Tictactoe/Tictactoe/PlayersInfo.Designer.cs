namespace Tictactoe
{
    partial class PlayersInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PlayersInfo));
            this.player02Name = new System.Windows.Forms.TextBox();
            this.player02Mark = new System.Windows.Forms.PictureBox();
            this.player01Name = new System.Windows.Forms.TextBox();
            this.player01Mark = new System.Windows.Forms.PictureBox();
            this.btnConfirm = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.player02Mark)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.player01Mark)).BeginInit();
            this.SuspendLayout();
            // 
            // player02Name
            // 
            this.player02Name.Location = new System.Drawing.Point(249, 170);
            this.player02Name.Name = "player02Name";
            this.player02Name.Size = new System.Drawing.Size(157, 32);
            this.player02Name.TabIndex = 0;
            this.player02Name.Text = "Player 2";
            this.player02Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // player02Mark
            // 
            this.player02Mark.BackgroundImage = global::Tictactoe.Properties.Resources.tac;
            this.player02Mark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player02Mark.Location = new System.Drawing.Point(249, 12);
            this.player02Mark.Name = "player02Mark";
            this.player02Mark.Size = new System.Drawing.Size(157, 152);
            this.player02Mark.TabIndex = 1;
            this.player02Mark.TabStop = false;
            this.player02Mark.Click += new System.EventHandler(this.playerMark_Click);
            // 
            // player01Name
            // 
            this.player01Name.Location = new System.Drawing.Point(12, 171);
            this.player01Name.Name = "player01Name";
            this.player01Name.Size = new System.Drawing.Size(157, 32);
            this.player01Name.TabIndex = 0;
            this.player01Name.Text = "Player 1";
            this.player01Name.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // player01Mark
            // 
            this.player01Mark.BackgroundImage = global::Tictactoe.Properties.Resources.tic;
            this.player01Mark.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.player01Mark.Location = new System.Drawing.Point(12, 12);
            this.player01Mark.Name = "player01Mark";
            this.player01Mark.Size = new System.Drawing.Size(157, 152);
            this.player01Mark.TabIndex = 1;
            this.player01Mark.TabStop = false;
            this.player01Mark.Click += new System.EventHandler(this.playerMark_Click);
            // 
            // btnConfirm
            // 
            this.btnConfirm.Location = new System.Drawing.Point(12, 209);
            this.btnConfirm.Name = "btnConfirm";
            this.btnConfirm.Size = new System.Drawing.Size(394, 49);
            this.btnConfirm.TabIndex = 2;
            this.btnConfirm.Text = "Confirm";
            this.btnConfirm.UseVisualStyleBackColor = true;
            this.btnConfirm.Click += new System.EventHandler(this.btnConfirm_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Modern No. 20", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(176, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 31);
            this.label1.TabIndex = 3;
            this.label1.Text = "VS";
            // 
            // PlayersInfo
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Tictactoe.Properties.Resources.icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(418, 268);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConfirm);
            this.Controls.Add(this.player01Mark);
            this.Controls.Add(this.player01Name);
            this.Controls.Add(this.player02Mark);
            this.Controls.Add(this.player02Name);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Modern No. 20", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.Name = "PlayersInfo";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Players Information";
            ((System.ComponentModel.ISupportInitialize)(this.player02Mark)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.player01Mark)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox player02Name;
        private System.Windows.Forms.PictureBox player02Mark;
        private System.Windows.Forms.TextBox player01Name;
        private System.Windows.Forms.PictureBox player01Mark;
        private System.Windows.Forms.Button btnConfirm;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
    }
}