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
    public partial class FormGameWindow : FormCustomBorderBase, IGameWindowView
    {
        private readonly GameWindowGui _gameWindowGui;

        private readonly Color _normalBackColor = Color.Green;
        private readonly Color _hoverMinimalizeBackColor = Color.SeaGreen;
        private readonly Color _hoverCloseBackColor = Color.DarkRed;
        private readonly Color _downMinimalizeBackColor = Color.DarkSlateGray;
        private readonly Color _downCloseBackColor = Color.Maroon;

        public FormGameWindow()
        {
            InitializeComponent();

            _gameWindowGui = new GameWindowGui(this);

            foreach (var control in new[] { labelWindowMinimize, labelWindowClose })
            {
                control.MouseEnter += (s, e) => SetLabelColors((Control)s, CustomBorderMouseState.Hover);
                control.MouseLeave += (s, e) => SetLabelColors((Control)s, CustomBorderMouseState.Normal);
                control.MouseDown += (s, e) => SetLabelColors((Control)s, CustomBorderMouseState.Down);
            }

            labelWindowMinimize.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) WindowState = FormWindowState.Minimized;
                labelWindowMinimize.BackColor = _normalBackColor;
            };
            labelWindowClose.MouseClick += (s, e) =>
            {
                if (e.Button == MouseButtons.Left) Close();
                labelWindowClose.BackColor = _normalBackColor;
            };
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

        #region WindowSetup

        private void FormGameWindow_Paint(object sender, PaintEventArgs e)
        {
            var rect = e.ClipRectangle;
            rect.X += 1;
            rect.Y += 1;
            rect.Width -= 3;
            rect.Height -= 3;
            e.Graphics.DrawRectangle(new Pen(Color.DarkGreen, 3f), rect);
        }
        
        private void labelWindowTitle_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
                DecorationMouseDown(HitTestValues.HTCAPTION);
        }

        private void SetLabelColors(Control control, CustomBorderMouseState mouseState)
        {
            if (!ContainsFocus) return;

            var backColor = _normalBackColor;

            switch (mouseState)
            {
                case CustomBorderMouseState.Hover:
                    backColor = control == labelWindowClose ? _hoverCloseBackColor : _hoverMinimalizeBackColor;
                    break;
                case CustomBorderMouseState.Down:
                    backColor = control == labelWindowClose ? _downCloseBackColor : _downMinimalizeBackColor;
                    break;
            }
            
            control.BackColor = backColor;
        }
        
        private void FormGameWindow_Load(object sender, EventArgs e)
        {
            this.ClientSize = new Size(724 + 400, 691);
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

        #endregion





        private void gameCanvas_Load(object sender, EventArgs e)
        {
            _gameWindowGui.GameWindowLoaded();
        }

        private void buttonEndTurn_Click(object sender, EventArgs e)
        {
            _gameWindowGui.TEST_EndTurn();
        }
    }
}
