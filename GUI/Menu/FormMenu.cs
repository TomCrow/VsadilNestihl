using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VsadilNestihl.GUI.Menu
{
    public partial class FormMenu : Form, IMenuView
    {
        private readonly Menu _menu;

        public FormMenu()
        {
            InitializeComponent();
            _menu = new Menu(this);
        }

        public Menu GetMenu()
        {
            return _menu;
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

        private void buttonSoloGame_Click(object sender, EventArgs e)
        {
            _menu.SoloGameClick();
        }

        private void buttonHostGame_Click(object sender, EventArgs e)
        {
            _menu.HostGameClick();
        }

        private void buttonJoinGame_Click(object sender, EventArgs e)
        {
            _menu.JoinGameClick();
        }
    }
}
