namespace VsadilNestihl.GUI.NetworkLobby
{
    partial class LobbyPlayer
    {
        /// <summary> 
        /// Vyžaduje se proměnná návrháře.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Uvolněte všechny používané prostředky.
        /// </summary>
        /// <param name="disposing">hodnota true, když by se měl spravovaný prostředek odstranit; jinak false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kód vygenerovaný pomocí Návrháře komponent

        /// <summary> 
        /// Metoda vyžadovaná pro podporu Návrháře - neupravovat
        /// obsah této metody v editoru kódu.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelPlayerName = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panelPlayer = new System.Windows.Forms.Panel();
            this.buttonColor = new System.Windows.Forms.Button();
            this.labelEmptySpace = new System.Windows.Forms.Label();
            this.panelPlayer.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelPlayerName
            // 
            this.labelPlayerName.AutoSize = true;
            this.labelPlayerName.Location = new System.Drawing.Point(82, 8);
            this.labelPlayerName.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelPlayerName.Name = "labelPlayerName";
            this.labelPlayerName.Size = new System.Drawing.Size(39, 13);
            this.labelPlayerName.TabIndex = 0;
            this.labelPlayerName.Text = "Hráč 1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(7, 8);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(71, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Jméno hráče:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(7, 37);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(38, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Barva:";
            // 
            // panelPlayer
            // 
            this.panelPlayer.Controls.Add(this.buttonColor);
            this.panelPlayer.Controls.Add(this.label2);
            this.panelPlayer.Controls.Add(this.label3);
            this.panelPlayer.Controls.Add(this.labelPlayerName);
            this.panelPlayer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPlayer.Location = new System.Drawing.Point(0, 0);
            this.panelPlayer.Margin = new System.Windows.Forms.Padding(0);
            this.panelPlayer.Name = "panelPlayer";
            this.panelPlayer.Size = new System.Drawing.Size(206, 65);
            this.panelPlayer.TabIndex = 4;
            this.panelPlayer.Visible = false;
            // 
            // buttonColor
            // 
            this.buttonColor.BackColor = System.Drawing.Color.Red;
            this.buttonColor.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonColor.Location = new System.Drawing.Point(50, 31);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(25, 25);
            this.buttonColor.TabIndex = 4;
            this.buttonColor.UseVisualStyleBackColor = false;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // labelEmptySpace
            // 
            this.labelEmptySpace.Dock = System.Windows.Forms.DockStyle.Fill;
            this.labelEmptySpace.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.labelEmptySpace.Location = new System.Drawing.Point(0, 0);
            this.labelEmptySpace.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.labelEmptySpace.Name = "labelEmptySpace";
            this.labelEmptySpace.Size = new System.Drawing.Size(206, 65);
            this.labelEmptySpace.TabIndex = 5;
            this.labelEmptySpace.Text = "Volné místo";
            this.labelEmptySpace.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelEmptySpace.Click += new System.EventHandler(this.labelEmptySpace_Click);
            this.labelEmptySpace.MouseEnter += new System.EventHandler(this.labelEmptySpace_MouseEnter);
            this.labelEmptySpace.MouseLeave += new System.EventHandler(this.labelEmptySpace_MouseLeave);
            // 
            // LobbyPlayer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.panelPlayer);
            this.Controls.Add(this.labelEmptySpace);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "LobbyPlayer";
            this.Size = new System.Drawing.Size(206, 65);
            this.panelPlayer.ResumeLayout(false);
            this.panelPlayer.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label labelPlayerName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panelPlayer;
        private System.Windows.Forms.Label labelEmptySpace;
        private System.Windows.Forms.Button buttonColor;
    }
}
