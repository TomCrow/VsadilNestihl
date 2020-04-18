namespace VsadilNestihl.GUI.NetworkLobby
{
    partial class FormNetworkLobby
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormNetworkLobby));
            this.richTextBoxChat = new System.Windows.Forms.RichTextBox();
            this.textBoxChat = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.buttonChatSend = new System.Windows.Forms.Button();
            this.panelSpectators = new System.Windows.Forms.Panel();
            this.buttonJoinSpectators = new System.Windows.Forms.Button();
            this.labelSpectatorsList = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lobbyPlayer6 = new VsadilNestihl.GUI.NetworkLobby.LobbyPlayer();
            this.lobbyPlayer5 = new VsadilNestihl.GUI.NetworkLobby.LobbyPlayer();
            this.lobbyPlayer4 = new VsadilNestihl.GUI.NetworkLobby.LobbyPlayer();
            this.lobbyPlayer3 = new VsadilNestihl.GUI.NetworkLobby.LobbyPlayer();
            this.lobbyPlayer2 = new VsadilNestihl.GUI.NetworkLobby.LobbyPlayer();
            this.lobbyPlayer1 = new VsadilNestihl.GUI.NetworkLobby.LobbyPlayer();
            this.buttonStart = new System.Windows.Forms.Button();
            this.panelSpectators.SuspendLayout();
            this.SuspendLayout();
            // 
            // richTextBoxChat
            // 
            this.richTextBoxChat.Location = new System.Drawing.Point(304, 12);
            this.richTextBoxChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.richTextBoxChat.Name = "richTextBoxChat";
            this.richTextBoxChat.ReadOnly = true;
            this.richTextBoxChat.Size = new System.Drawing.Size(484, 382);
            this.richTextBoxChat.TabIndex = 0;
            this.richTextBoxChat.Text = "";
            // 
            // textBoxChat
            // 
            this.textBoxChat.Location = new System.Drawing.Point(348, 402);
            this.textBoxChat.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.textBoxChat.MaxLength = 1000;
            this.textBoxChat.Name = "textBoxChat";
            this.textBoxChat.Size = new System.Drawing.Size(367, 22);
            this.textBoxChat.TabIndex = 1;
            this.textBoxChat.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxChat_KeyDown);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(301, 405);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 17);
            this.label1.TabIndex = 2;
            this.label1.Text = "Chat:";
            // 
            // buttonChatSend
            // 
            this.buttonChatSend.AutoSize = true;
            this.buttonChatSend.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.buttonChatSend.Location = new System.Drawing.Point(721, 400);
            this.buttonChatSend.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonChatSend.Name = "buttonChatSend";
            this.buttonChatSend.Size = new System.Drawing.Size(67, 27);
            this.buttonChatSend.TabIndex = 3;
            this.buttonChatSend.Text = "Odeslat";
            this.buttonChatSend.UseVisualStyleBackColor = true;
            this.buttonChatSend.Click += new System.EventHandler(this.buttonChatSend_Click);
            // 
            // panelSpectators
            // 
            this.panelSpectators.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelSpectators.Controls.Add(this.buttonJoinSpectators);
            this.panelSpectators.Controls.Add(this.labelSpectatorsList);
            this.panelSpectators.Controls.Add(this.label2);
            this.panelSpectators.Location = new System.Drawing.Point(304, 442);
            this.panelSpectators.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.panelSpectators.Name = "panelSpectators";
            this.panelSpectators.Size = new System.Drawing.Size(274, 80);
            this.panelSpectators.TabIndex = 10;
            // 
            // buttonJoinSpectators
            // 
            this.buttonJoinSpectators.AutoSize = true;
            this.buttonJoinSpectators.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonJoinSpectators.Location = new System.Drawing.Point(175, -1);
            this.buttonJoinSpectators.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonJoinSpectators.Name = "buttonJoinSpectators";
            this.buttonJoinSpectators.Size = new System.Drawing.Size(133, 36);
            this.buttonJoinSpectators.TabIndex = 11;
            this.buttonJoinSpectators.Text = "Sledovat hru";
            this.buttonJoinSpectators.UseVisualStyleBackColor = true;
            this.buttonJoinSpectators.Click += new System.EventHandler(this.buttonJoinSpectators_Click);
            // 
            // labelSpectatorsList
            // 
            this.labelSpectatorsList.Location = new System.Drawing.Point(3, 20);
            this.labelSpectatorsList.Name = "labelSpectatorsList";
            this.labelSpectatorsList.Size = new System.Drawing.Size(267, 58);
            this.labelSpectatorsList.TabIndex = 1;
            this.labelSpectatorsList.Text = "-";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(3, 2);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(50, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Diváci:";
            // 
            // lobbyPlayer6
            // 
            this.lobbyPlayer6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lobbyPlayer6.Location = new System.Drawing.Point(12, 442);
            this.lobbyPlayer6.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyPlayer6.Name = "lobbyPlayer6";
            this.lobbyPlayer6.Size = new System.Drawing.Size(274, 80);
            this.lobbyPlayer6.TabIndex = 9;
            // 
            // lobbyPlayer5
            // 
            this.lobbyPlayer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lobbyPlayer5.Location = new System.Drawing.Point(12, 356);
            this.lobbyPlayer5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyPlayer5.Name = "lobbyPlayer5";
            this.lobbyPlayer5.Size = new System.Drawing.Size(274, 80);
            this.lobbyPlayer5.TabIndex = 8;
            // 
            // lobbyPlayer4
            // 
            this.lobbyPlayer4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lobbyPlayer4.Location = new System.Drawing.Point(12, 270);
            this.lobbyPlayer4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyPlayer4.Name = "lobbyPlayer4";
            this.lobbyPlayer4.Size = new System.Drawing.Size(274, 80);
            this.lobbyPlayer4.TabIndex = 7;
            // 
            // lobbyPlayer3
            // 
            this.lobbyPlayer3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lobbyPlayer3.Location = new System.Drawing.Point(12, 185);
            this.lobbyPlayer3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyPlayer3.Name = "lobbyPlayer3";
            this.lobbyPlayer3.Size = new System.Drawing.Size(274, 80);
            this.lobbyPlayer3.TabIndex = 6;
            // 
            // lobbyPlayer2
            // 
            this.lobbyPlayer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lobbyPlayer2.Location = new System.Drawing.Point(12, 98);
            this.lobbyPlayer2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyPlayer2.Name = "lobbyPlayer2";
            this.lobbyPlayer2.Size = new System.Drawing.Size(274, 80);
            this.lobbyPlayer2.TabIndex = 5;
            // 
            // lobbyPlayer1
            // 
            this.lobbyPlayer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lobbyPlayer1.Location = new System.Drawing.Point(12, 12);
            this.lobbyPlayer1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.lobbyPlayer1.Name = "lobbyPlayer1";
            this.lobbyPlayer1.Size = new System.Drawing.Size(274, 80);
            this.lobbyPlayer1.TabIndex = 4;
            // 
            // buttonStart
            // 
            this.buttonStart.Enabled = false;
            this.buttonStart.Location = new System.Drawing.Point(619, 445);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(152, 63);
            this.buttonStart.TabIndex = 11;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // FormNetworkLobby
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 534);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.panelSpectators);
            this.Controls.Add(this.lobbyPlayer6);
            this.Controls.Add(this.lobbyPlayer5);
            this.Controls.Add(this.lobbyPlayer4);
            this.Controls.Add(this.lobbyPlayer3);
            this.Controls.Add(this.lobbyPlayer2);
            this.Controls.Add(this.lobbyPlayer1);
            this.Controls.Add(this.buttonChatSend);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBoxChat);
            this.Controls.Add(this.richTextBoxChat);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.Name = "FormNetworkLobby";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Network lobby";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormNetworkLobby_FormClosed);
            this.panelSpectators.ResumeLayout(false);
            this.panelSpectators.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox richTextBoxChat;
        private System.Windows.Forms.TextBox textBoxChat;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonChatSend;
        private LobbyPlayer lobbyPlayer1;
        private LobbyPlayer lobbyPlayer2;
        private LobbyPlayer lobbyPlayer3;
        private LobbyPlayer lobbyPlayer4;
        private LobbyPlayer lobbyPlayer5;
        private LobbyPlayer lobbyPlayer6;
        private System.Windows.Forms.Panel panelSpectators;
        private System.Windows.Forms.Label labelSpectatorsList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button buttonJoinSpectators;
        private System.Windows.Forms.Button buttonStart;
    }
}