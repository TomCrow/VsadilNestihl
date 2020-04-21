using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.GUI.Extensions;
using VsadilNestihl.GUI.GameCanvas;

namespace VsadilNestihl.GUI.GameWindow
{
    public partial class FormGameWindow : Form, IGameWindowView
    {
        private readonly GameWindowGui _gameWindowGui;

        public FormGameWindow()
        {
            InitializeComponent();

            _gameWindowGui = new GameWindowGui(this);
        }
        
        public GameWindowGui GetGameWindowGui()
        {
            return _gameWindowGui;
        }

        public void AddChatMessage(string message)
        {
            this.InvokeIfRequired(() =>
            {
                if (!string.IsNullOrWhiteSpace(richTextBoxChat.Text))
                {
                    richTextBoxChat.AppendText("\r\n" + message);
                }
                else
                {
                    richTextBoxChat.AppendText(message);
                }
                richTextBoxChat.ScrollToCaret();
            });
        }

        public void ShowGameActionException(string message)
        {
            this.InvokeIfRequired(() =>
            {
                MessageBox.Show(message, "GAME ACTION EXCEPTION", MessageBoxButtons.OK, MessageBoxIcon.Error);
            });

        }

        public void AddDrawable(IDrawable drawable)
        {
            gameCanvas.AddDrawable(drawable);
        }

        public void AddDrawables(IEnumerable<IDrawable> drawables)
        {
            gameCanvas.AddDrawables(drawables);
        }

        public void RemoveDrawable(IDrawable drawable)
        {
            gameCanvas.RemoveDrawable(drawable);
        }

        public void RefreshCanvas()
        {
            gameCanvas.RefreshCanvas();
        }

        private void gameCanvas_Load(object sender, EventArgs e)
        {
            _gameWindowGui.GameWindowLoaded();
        }

        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            _gameWindowGui.TEST_EndTurn();
        }

        private void FormGameWindow_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(724 + 400, 724);
        }

        private void textBoxChat_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonChatSend.PerformClick();
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void buttonChatSend_Click(object sender, EventArgs e)
        {
            var message = textBoxChat.Text;
            if (string.IsNullOrWhiteSpace(message))
                return;

            textBoxChat.Clear();
            _gameWindowGui.ChatSendMessageClick(message);
        }
    }
}
