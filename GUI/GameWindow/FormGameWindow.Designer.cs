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
            this.buttonChatSend = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.labelWindowTitle = new System.Windows.Forms.Label();
            this.labelWindowClose = new System.Windows.Forms.Label();
            this.labelWindowMinimize = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // gameCanvas
            // 
            this.gameCanvas.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.gameCanvas.Location = new System.Drawing.Point(3, 3);
            this.gameCanvas.Margin = new System.Windows.Forms.Padding(0);
            this.gameCanvas.Name = "gameCanvas";
            this.gameCanvas.Size = new System.Drawing.Size(1160, 578);
            this.gameCanvas.TabIndex = 0;
            this.gameCanvas.Load += new System.EventHandler(this.gameCanvas_Load);
            // 
            // buttonEndTurn
            // 
            this.buttonEndTurn.Location = new System.Drawing.Point(401, 192);
            this.buttonEndTurn.Name = "buttonEndTurn";
            this.buttonEndTurn.Size = new System.Drawing.Size(98, 46);
            this.buttonEndTurn.TabIndex = 1;
            this.buttonEndTurn.Text = "Ukončit kolo";
            this.buttonEndTurn.UseVisualStyleBackColor = true;
            this.buttonEndTurn.Click += new System.EventHandler(this.buttonEndTurn_Click);
            // 
            // buttonChatSend
            // 
            this.buttonChatSend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonChatSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChatSend.Location = new System.Drawing.Point(1080, 353);
            this.buttonChatSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChatSend.Name = "buttonChatSend";
            this.buttonChatSend.Size = new System.Drawing.Size(74, 23);
            this.buttonChatSend.TabIndex = 7;
            this.buttonChatSend.Text = "Odeslat";
            this.buttonChatSend.UseVisualStyleBackColor = true;
            this.buttonChatSend.Click += new System.EventHandler(this.buttonChatSend_Click);
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(775, 351);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(38, 25);
            this.label1.TabIndex = 6;
            this.label1.Text = "Chat:";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBoxChat
            // 
            this.textBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxChat.Location = new System.Drawing.Point(819, 355);
            this.textBoxChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxChat.MaxLength = 1000;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(255, 20);
            this.textBoxChat.TabIndex = 5;
            this.textBoxChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyDown);
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBoxChat.BackColor = System.Drawing.Color.White;
            this.richTextBoxChat.Location = new System.Drawing.Point(778, 34);
            this.richTextBoxChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(376, 315);
            this.richTextBoxChat.TabIndex = 4;
            this.richTextBoxChat.Text = "";
            // 
            // labelWindowTitle
            // 
            this.labelWindowTitle.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWindowTitle.BackColor = System.Drawing.Color.DarkGreen;
            this.labelWindowTitle.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWindowTitle.ForeColor = System.Drawing.Color.White;
            this.labelWindowTitle.Location = new System.Drawing.Point(727, 0);
            this.labelWindowTitle.Name = "labelWindowTitle";
            this.labelWindowTitle.Size = new System.Drawing.Size(439, 30);
            this.labelWindowTitle.TabIndex = 11;
            this.labelWindowTitle.Text = "Vsadil nestihl";
            this.labelWindowTitle.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.labelWindowTitle.MouseDown += new System.Windows.Forms.MouseEventHandler(this.labelWindowTitle_MouseDown);
            // 
            // labelWindowClose
            // 
            this.labelWindowClose.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWindowClose.BackColor = System.Drawing.Color.White;
            this.labelWindowClose.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWindowClose.Location = new System.Drawing.Point(1139, 3);
            this.labelWindowClose.Name = "labelWindowClose";
            this.labelWindowClose.Size = new System.Drawing.Size(24, 24);
            this.labelWindowClose.TabIndex = 12;
            this.labelWindowClose.Text = "X";
            this.labelWindowClose.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // labelWindowMinimize
            // 
            this.labelWindowMinimize.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.labelWindowMinimize.BackColor = System.Drawing.Color.White;
            this.labelWindowMinimize.Font = new System.Drawing.Font("Marlett", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelWindowMinimize.Location = new System.Drawing.Point(1112, 3);
            this.labelWindowMinimize.Name = "labelWindowMinimize";
            this.labelWindowMinimize.Size = new System.Drawing.Size(24, 24);
            this.labelWindowMinimize.TabIndex = 13;
            this.labelWindowMinimize.Text = "_";
            this.labelWindowMinimize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormGameWindow
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1166, 584);
            this.Controls.Add(this.labelWindowMinimize);
            this.Controls.Add(this.labelWindowClose);
            this.Controls.Add(this.labelWindowTitle);
            this.Controls.Add(this.buttonChatSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.richTextBoxChat);
            this.Controls.Add(this.buttonEndTurn);
            this.Controls.Add(this.gameCanvas);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Location = new System.Drawing.Point(0, 0);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "FormGameWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormGameWindow";
            this.Load += new System.EventHandler(this.FormGameWindow_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.FormGameWindow_Paint);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private GameCanvas.GameCanvasControl gameCanvas;
        private System.Windows.Forms.Button buttonEndTurn;
        private System.Windows.Forms.Button buttonChatSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.Label labelWindowTitle;
        private System.Windows.Forms.Label labelWindowClose;
        private System.Windows.Forms.Label labelWindowMinimize;
    }
}