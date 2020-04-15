namespace VsadilNestihl.GUI.GameWindow
{
    partial class FormNetworkGame
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
            this.gameCanvas = new VsadilNestihl.GUI.GameCanvas.GameCanvasControl();
            this.SuspendLayout();
            // 
            // gameCanvas
            // 
            this.gameCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameCanvas.Location = new System.Drawing.Point(0, 0);
            this.gameCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(800, 450);
            this.gameCanvas.TabIndex = 1;
            // 
            // FormNetworkGame
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.gameCanvas);
            this.Name = "FormNetworkGame";
            this.Text = "FormNetworkGame";
            this.ResumeLayout(false);

        }

        #endregion

        private GameCanvas.GameCanvasControl gameCanvas;
    }
}