using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.GUI.Extensions;

namespace VsadilNestihl.GUI.NetworkLobby
{
    public partial class LobbyPlayer : UserControl
    {
        public bool IsMe { get; private set; }

        public event Action EmptyPlayerClick;
        public event Action PlayerColorClick;

        public LobbyPlayer()
        {
            InitializeComponent();
        }

        public void SetLobbyPlayer(Playeyr.LobbyPlayer lobbyPlayer, bool isMe)
        {
            IsMe = isMe;

            this.InvokeIfRequired(() =>
            {
                labelPlayerName.Text = lobbyPlayer.PlayerName;
                buttonColor.BackColor = lobbyPlayer.Color;
                panelPlayer.BackColor = isMe ? Color.Aqua : SystemColors.Control;
                panelPlayer.Visible = true;
            });
        }

        public void SetEmpty()
        {
            this.InvokeIfRequired(() => { panelPlayer.Visible = false; });
        }

        private void labelEmptySpace_MouseEnter(object sender, EventArgs e)
        {
            labelEmptySpace.BackColor = Color.MistyRose;
        }

        private void labelEmptySpace_MouseLeave(object sender, EventArgs e)
        {
            labelEmptySpace.BackColor = SystemColors.Control;
        }

        private void labelEmptySpace_Click(object sender, EventArgs e)
        {
            EmptyPlayerClick?.Invoke();
        }
        
        private void buttonColor_Click(object sender, EventArgs e)
        {
            PlayerColorClick?.Invoke();
        }
    }
}
