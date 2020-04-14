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
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHostPort)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJoinPort)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonSoloGame
            // 
            this.buttonSoloGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonSoloGame.Location = new System.Drawing.Point(502, 144);
            this.buttonSoloGame.Name = "buttonSoloGame";
            this.buttonSoloGame.Size = new System.Drawing.Size(149, 35);
            this.buttonSoloGame.TabIndex = 0;
            this.buttonSoloGame.Text = "Sólo hra";
            this.buttonSoloGame.UseVisualStyleBackColor = true;
            this.buttonSoloGame.Click += new System.EventHandler(this.buttonSoloGame_Click);
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(502, 96);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(94, 17);
            this.labelPlayerName.TabIndex = 1;
            this.labelPlayerName.Text = "Jméno hráče:";
            // 
            // textBoxPlayerName
            // 
            this.textBoxPlayerName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxPlayerName.Location = new System.Drawing.Point(502, 116);
            this.textBoxPlayerName.Name = "textBoxPlayerName";
            this.textBoxPlayerName.Size = new System.Drawing.Size(149, 22);
            this.textBoxPlayerName.TabIndex = 2;
            // 
            // buttonHostGame
            // 
            this.buttonHostGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonHostGame.Location = new System.Drawing.Point(502, 213);
            this.buttonHostGame.Name = "buttonHostGame";
            this.buttonHostGame.Size = new System.Drawing.Size(149, 35);
            this.buttonHostGame.TabIndex = 3;
            this.buttonHostGame.Text = "Hostovat hru";
            this.buttonHostGame.UseVisualStyleBackColor = true;
            this.buttonHostGame.Click += new System.EventHandler(this.buttonHostGame_Click);
            // 
            // buttonJoinGame
            // 
            this.buttonJoinGame.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonJoinGame.Location = new System.Drawing.Point(502, 310);
            this.buttonJoinGame.Name = "buttonJoinGame";
            this.buttonJoinGame.Size = new System.Drawing.Size(149, 35);
            this.buttonJoinGame.TabIndex = 4;
            this.buttonJoinGame.Text = "Připojit se ke hře";
            this.buttonJoinGame.UseVisualStyleBackColor = true;
            this.buttonJoinGame.Click += new System.EventHandler(this.buttonJoinGame_Click);
            // 
            // labelHostPort
            // 
            this.labelHostPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelHostPort.AutoSize = true;
            this.labelHostPort.Location = new System.Drawing.Point(502, 187);
            this.labelHostPort.Name = "labelHostPort";
            this.labelHostPort.Size = new System.Drawing.Size(38, 17);
            this.labelHostPort.TabIndex = 5;
            this.labelHostPort.Text = "Port:";
            // 
            // numericUpDownHostPort
            // 
            this.numericUpDownHostPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownHostPort.Location = new System.Drawing.Point(546, 185);
            this.numericUpDownHostPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownHostPort.Name = "numericUpDownHostPort";
            this.numericUpDownHostPort.Size = new System.Drawing.Size(105, 22);
            this.numericUpDownHostPort.TabIndex = 6;
            this.numericUpDownHostPort.Value = new decimal(new int[] {
            42121,
            0,
            0,
            0});
            // 
            // numericUpDownJoinPort
            // 
            this.numericUpDownJoinPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.numericUpDownJoinPort.Location = new System.Drawing.Point(546, 282);
            this.numericUpDownJoinPort.Maximum = new decimal(new int[] {
            99999,
            0,
            0,
            0});
            this.numericUpDownJoinPort.Name = "numericUpDownJoinPort";
            this.numericUpDownJoinPort.Size = new System.Drawing.Size(105, 22);
            this.numericUpDownJoinPort.TabIndex = 8;
            this.numericUpDownJoinPort.Value = new decimal(new int[] {
            42121,
            0,
            0,
            0});
            // 
            // labelJoinPort
            // 
            this.labelJoinPort.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJoinPort.AutoSize = true;
            this.labelJoinPort.Location = new System.Drawing.Point(502, 284);
            this.labelJoinPort.Name = "labelJoinPort";
            this.labelJoinPort.Size = new System.Drawing.Size(38, 17);
            this.labelJoinPort.TabIndex = 7;
            this.labelJoinPort.Text = "Port:";
            // 
            // labelJoinIp
            // 
            this.labelJoinIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.labelJoinIp.AutoSize = true;
            this.labelJoinIp.Location = new System.Drawing.Point(502, 257);
            this.labelJoinIp.Name = "labelJoinIp";
            this.labelJoinIp.Size = new System.Drawing.Size(24, 17);
            this.labelJoinIp.TabIndex = 9;
            this.labelJoinIp.Text = "IP:";
            // 
            // textBoxJoinIp
            // 
            this.textBoxJoinIp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxJoinIp.Location = new System.Drawing.Point(532, 254);
            this.textBoxJoinIp.Name = "textBoxJoinIp";
            this.textBoxJoinIp.Size = new System.Drawing.Size(119, 22);
            this.textBoxJoinIp.TabIndex = 10;
            // 
            // FormMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(663, 357);
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
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FormMenu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Menu";
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownHostPort)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownJoinPort)).EndInit();
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
    }
}