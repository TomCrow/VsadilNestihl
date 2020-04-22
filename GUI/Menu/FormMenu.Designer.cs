namespace VsadilNestihl.GUI.Menu
{
    partial class FormMenu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMenu));
            this.buttonSoloGame = new System.Windows.Forms.Button();
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.textBoxPlayerName = new System.Windows.Forms.TextBox();
            this.buttonHostGame = new System.Windows.Forms.Button();
            this.buttonJoinGame = new System.Windows.Forms.Button();
            this.labelHostPort = new System.Windows.Forms.Label();
            this.numericUpDownHostPort = new System.Windows.Forms.NumericUpDown();
            this.numericUpDownJoinPort = new System.Windows.Forms.NumericUpDown();
            this.labelJoinPort = new System.Windows.Forms.Label();
            this.labelJoinIp = new System.Windows.Forms.Label();
            this.textBoxJoinIp = new System.Windows.Forms.TextBox();
            this.pictureBoxBackground = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHostPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJoinPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSoloGame
            // 
            this.buttonSoloGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSoloGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonSoloGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSoloGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonSoloGame.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonSoloGame.Location = new System.Drawing.Point(677, 81);
            this.buttonSoloGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonSoloGame.Name = "buttonSoloGame";
            this.buttonSoloGame.Size = new System.Drawing.Size(292, 34);
            this.buttonSoloGame.TabIndex = 0;
            this.buttonSoloGame.Text = "Sólo hra";
            this.buttonSoloGame.UseVisualStyleBackColor = false;
            this.buttonSoloGame.Click += new System.EventHandler(this.buttonSoloGame_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.BackColor = System.Drawing.Color.Transparent;
            this.labelPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelPlayerName.ForeColor = System.Drawing.Color.White;
            this.labelPlayerName.Location = new System.Drawing.Point(672, 10);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(117, 20);
            this.labelPlayerName.TabIndex = 1;
            this.labelPlayerName.Text = "Jméno hráče:";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayerName.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxPlayerName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxPlayerName.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxPlayerName.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxPlayerName.Location = new System.Drawing.Point(677, 37);
            this.textBoxPlayerName.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(293, 26);
            this.textBoxPlayerName.TabIndex = 2;
            this.textBoxPlayerName.Text = "Hráč";
            // 
            // buttonHostGame
            // 
            this.buttonHostGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHostGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonHostGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonHostGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonHostGame.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonHostGame.Location = new System.Drawing.Point(677, 159);
            this.buttonHostGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonHostGame.Name = "buttonHostGame";
            this.buttonHostGame.Size = new System.Drawing.Size(292, 34);
            this.buttonHostGame.TabIndex = 3;
            this.buttonHostGame.Text = "Hostovat hru";
            this.buttonHostGame.UseVisualStyleBackColor = false;
            this.buttonHostGame.Click += new System.EventHandler(this.buttonHostGame_Click);
            // 
            // buttonJoinGame
            // 
            this.buttonJoinGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJoinGame.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.buttonJoinGame.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJoinGame.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.buttonJoinGame.ForeColor = System.Drawing.Color.Gainsboro;
            this.buttonJoinGame.Location = new System.Drawing.Point(677, 272);
            this.buttonJoinGame.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonJoinGame.Name = "buttonJoinGame";
            this.buttonJoinGame.Size = new System.Drawing.Size(292, 34);
            this.buttonJoinGame.TabIndex = 4;
            this.buttonJoinGame.Text = "Připojit se ke hře";
            this.buttonJoinGame.UseVisualStyleBackColor = false;
            this.buttonJoinGame.Click += new System.EventHandler(this.buttonJoinGame_Click);
            // 
            // labelHostPort
            // 
            this.labelHostPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHostPort.AutoSize = true;
            this.labelHostPort.BackColor = System.Drawing.Color.Transparent;
            this.labelHostPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelHostPort.ForeColor = System.Drawing.Color.White;
            this.labelHostPort.Location = new System.Drawing.Point(672, 127);
            this.labelHostPort.Name = "labelHostPort";
            this.labelHostPort.Size = new System.Drawing.Size(47, 20);
            this.labelHostPort.TabIndex = 5;
            this.labelHostPort.Text = "Port:";
            // 
            // numericUpDownHostPort
            // 
            this.numericUpDownHostPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownHostPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownHostPort.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.numericUpDownHostPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownHostPort.ForeColor = System.Drawing.Color.Gainsboro;
            this.numericUpDownHostPort.Location = new System.Drawing.Point(736, 125);
            this.numericUpDownHostPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownHostPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownHostPort.Name = "numericUpDownHostPort";
            this.numericUpDownHostPort.Size = new System.Drawing.Size(233, 26);
            this.numericUpDownHostPort.TabIndex = 6;
            this.numericUpDownHostPort.Value = new decimal(new int[] {
            42121,
            0,
            0,
            0});
            // 
            // numericUpDownJoinPort
            // 
            this.numericUpDownJoinPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownJoinPort.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.numericUpDownJoinPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.numericUpDownJoinPort.ForeColor = System.Drawing.Color.Gainsboro;
            this.numericUpDownJoinPort.Location = new System.Drawing.Point(736, 238);
            this.numericUpDownJoinPort.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.numericUpDownJoinPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownJoinPort.Name = "numericUpDownJoinPort";
            this.numericUpDownJoinPort.Size = new System.Drawing.Size(233, 26);
            this.numericUpDownJoinPort.TabIndex = 8;
            this.numericUpDownJoinPort.Value = new decimal(new int[] {
            42121,
            0,
            0,
            0});
            // 
            // labelJoinPort
            // 
            this.labelJoinPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJoinPort.AutoSize = true;
            this.labelJoinPort.BackColor = System.Drawing.Color.Transparent;
            this.labelJoinPort.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelJoinPort.ForeColor = System.Drawing.Color.White;
            this.labelJoinPort.Location = new System.Drawing.Point(672, 240);
            this.labelJoinPort.Name = "labelJoinPort";
            this.labelJoinPort.Size = new System.Drawing.Size(47, 20);
            this.labelJoinPort.TabIndex = 7;
            this.labelJoinPort.Text = "Port:";
            // 
            // labelJoinIp
            // 
            this.labelJoinIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJoinIp.AutoSize = true;
            this.labelJoinIp.BackColor = System.Drawing.Color.Transparent;
            this.labelJoinIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.labelJoinIp.ForeColor = System.Drawing.Color.White;
            this.labelJoinIp.Location = new System.Drawing.Point(672, 206);
            this.labelJoinIp.Name = "labelJoinIp";
            this.labelJoinIp.Size = new System.Drawing.Size(31, 20);
            this.labelJoinIp.TabIndex = 9;
            this.labelJoinIp.Text = "IP:";
            // 
            // textBoxJoinIp
            // 
            this.textBoxJoinIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJoinIp.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.textBoxJoinIp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxJoinIp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.textBoxJoinIp.ForeColor = System.Drawing.Color.Gainsboro;
            this.textBoxJoinIp.Location = new System.Drawing.Point(717, 204);
            this.textBoxJoinIp.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxJoinIp.Name = "textBoxJoinIp";
            this.textBoxJoinIp.Size = new System.Drawing.Size(252, 26);
            this.textBoxJoinIp.TabIndex = 10;
            this.textBoxJoinIp.Text = "127.0.0.1";
            // 
            // pictureBoxBackground
            // 
            this.pictureBoxBackground.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxBackground.Image = global::VsadilNestihl.Properties.Resources.menu_background1;
            this.pictureBoxBackground.Location = new System.Drawing.Point(0, 0);
            this.pictureBoxBackground.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBoxBackground.Name = "pictureBoxBackground";
            this.pictureBoxBackground.Size = new System.Drawing.Size(981, 514);
            this.pictureBoxBackground.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxBackground.TabIndex = 11;
            this.pictureBoxBackground.TabStop = false;
            // 
            // FormMenu
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(981, 514);
            this.Controls.Add(this.textBoxJoinIp);
            this.Controls.Add(this.labelJoinIp);
            this.Controls.Add(this.numericUpDownJoinPort);
            this.Controls.Add(this.labelJoinPort);
            this.Controls.Add(this.numericUpDownHostPort);
            this.Controls.Add(this.labelHostPort);
            this.Controls.Add(this.buttonJoinGame);
            this.Controls.Add(this.buttonHostGame);
            this.Controls.Add(this.textBoxPlayerName);
            this.Controls.Add(this.labelPlayerName);
            this.Controls.Add(this.buttonSoloGame);
            this.Controls.Add(this.pictureBoxBackground);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Vsadil nestihl";
            this.Load += new System.EventHandler(this.FormMenu_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHostPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJoinPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxBackground)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonSoloGame;
        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.TextBox textBoxPlayerName;
        private System.Windows.Forms.Button buttonHostGame;
        private System.Windows.Forms.Button buttonJoinGame;
        private System.Windows.Forms.Label labelHostPort;
        private System.Windows.Forms.NumericUpDown numericUpDownHostPort;
        private System.Windows.Forms.NumericUpDown numericUpDownJoinPort;
        private System.Windows.Forms.Label labelJoinPort;
        private System.Windows.Forms.Label labelJoinIp;
        private System.Windows.Forms.TextBox textBoxJoinIp;
        private System.Windows.Forms.PictureBox pictureBoxBackground;
    }
}