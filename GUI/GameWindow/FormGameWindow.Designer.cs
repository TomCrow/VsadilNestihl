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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGameWindow));
            this.gameCanvas = new VsadilNestihl.GUI.GameCanvas.GameCanvasControl();
            this.buttonEndTurn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // gameCanvas
            // 
            this.gameCanvas.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gameCanvas.Location = new System.Drawing.Point(0, 0);
            this.gameCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(706, 677);
            this.gameCanvas.TabIndex = 0;
            this.gameCanvas.Load += new System.EventHandler(this.gameCanvas_Load);
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Location = new System.Drawing.Point(508, 311);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(98, 46);
            this.buttonEndTurn.TabIndex = 1;
            this.buttonEndTurn.Text = "Ukončit kolo";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // FormGameWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(706, 677);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.gameCanvas);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormGameWindow";
            this.Text = "FormGameWindow";
            this.ResumeLayout(false);

        }

        #endregion

        private GameCanvas.GameCanvasControl gameCanvas;
        private System.Windows.Forms.Button buttonEndTurn;
    }
}