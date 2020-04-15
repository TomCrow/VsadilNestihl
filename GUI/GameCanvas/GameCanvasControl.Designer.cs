namespace VsadilNestihl.GUI.GameCanvas
{
    partial class GameCanvasControl
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
            this.SuspendLayout();
            // 
            // GameCanvasControl
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.DoubleBuffered = true;
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "GameCanvasControl";
            this.Size = new System.Drawing.Size(162, 141);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.BoardControl_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.BoardControl_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.BoardControl_MouseUp);
            this.ResumeLayout(false);

        }

        #endregion
    }
}
