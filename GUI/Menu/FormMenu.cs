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

namespace VsadilNestihl.GUI.Menu
{
    public partial class FormMenu : Form, IMenuView
    {
        private readonly MenuGui _menuGui;

        public FormMenu()
        {
            InitializeComponent();

            labelPlayerName.Parent = pictureBoxBackground;
            labelHostPort.Parent = pictureBoxBackground;
            labelJoinIp.Parent = pictureBoxBackground;
            labelJoinPort.Parent = pictureBoxBackground;

            _menuGui = new MenuGui(this);
        }

        private void FormMenu_Load(object sender, EventArgs e)
        {

        }

        public MenuGui GetMenuGui()
        {
            return _menuGui;
        }

        public string GetPlayerName()
        {
            return textBoxPlayerName.Text;
        }

        public int GetHostPort()
        {
            return (int) numericUpDownHostPort.Value;
        }

        public string GetJoinIp()
        {
            return textBoxJoinIp.Text;
        }

        public int GetJoinPort()
        {
            return (int) numericUpDownJoinPort.Value;
        }

        public void ShowNameRequired()
        {
            MessageBox.Show($"Player name is required.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        public void ShowException(Exception exception)
        {
            MessageBox.Show($"Error: {exception.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        public void SetLoading(bool loading)
        {
            this.InvokeIfRequired(() =>
            {
                if (loading)
                    Cursor.Current = Cursors.WaitCursor;
                else
                    Cursor.Current = Cursors.Default;
            });
        }

        private void buttonSoloGame_Click(object sender, EventArgs e)
        {
            _menuGui.SoloGameClick();
        }

        private void buttonHostGame_Click(object sender, EventArgs e)
        {
            _menuGui.HostGameClick();
        }

        private void buttonJoinGame_Click(object sender, EventArgs e)
        {
            _menuGui.JoinGameClick();
        }
    }
}
