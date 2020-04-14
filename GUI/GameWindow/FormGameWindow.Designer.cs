namespace VsadilNestihl.GUI.GameWindow
{
    partial class FormGameWindow
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
            this.gameCanvas.Location = new System.Drawing.Point(12, 11);
            this.gameCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.gameCanvas.MaximumSize = new System.Drawing.Size(965, 891);
            this.gameCanvas.MinimumSize = new System.Drawing.Size(965, 891);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(965, 891);
            this.gameCanvas.TabIndex = 0;
            // 
            // FormGameWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1056, 935);
            this.Controls.Add(this.gameCanvas);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormGameWindow";
            this.Text = "FormGameWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private GameCanvas.GameCanvasControl gameCanvas;
    }
}