using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game.Lobby;
using VsadilNestihl.GUI.Extensions;

namespace VsadilNestihl.GUI.NetworkLobby
{
    public partial class FormNetworkLobby : Form, INetworkLobbyView
    {
        private readonly NetworkLobbyGui _networkLobbyGui;
        private int _myPlayerId;

        public FormNetworkLobby()
        {
            InitializeComponent();
            _networkLobbyGui = new NetworkLobbyGui(this);

            lobbyPlayer1.EmptyPlayerClick += () => _networkLobbyGui.EmptyPositionClick(PlayerPosition.Position1);
            lobbyPlayer2.EmptyPlayerClick += () => _networkLobbyGui.EmptyPositionClick(PlayerPosition.Position2);
            lobbyPlayer3.EmptyPlayerClick += () => _networkLobbyGui.EmptyPositionClick(PlayerPosition.Position3);
            lobbyPlayer4.EmptyPlayerClick += () => _networkLobbyGui.EmptyPositionClick(PlayerPosition.Position4);
            lobbyPlayer5.EmptyPlayerClick += () => _networkLobbyGui.EmptyPositionClick(PlayerPosition.Position5);
            lobbyPlayer6.EmptyPlayerClick += () => _networkLobbyGui.EmptyPositionClick(PlayerPosition.Position6);

            lobbyPlayer1.PlayerColorClick += () =>
            {
                if (lobbyPlayer1.IsMe)
                    _networkLobbyGui.ColorSwitchClick();
            };

            lobbyPlayer2.PlayerColorClick += () =>
            {
                if (lobbyPlayer2.IsMe)
                    _networkLobbyGui.ColorSwitchClick();
            };

            lobbyPlayer3.PlayerColorClick += () =>
            {
                if (lobbyPlayer3.IsMe)
                    _networkLobbyGui.ColorSwitchClick();
            };

            lobbyPlayer4.PlayerColorClick += () =>
            {
                if (lobbyPlayer4.IsMe)
                    _networkLobbyGui.ColorSwitchClick();
            };

            lobbyPlayer5.PlayerColorClick += () =>
            {
                if (lobbyPlayer5.IsMe)
                    _networkLobbyGui.ColorSwitchClick();
            };

            lobbyPlayer6.PlayerColorClick += () =>
            {
                if (lobbyPlayer6.IsMe)
                    _networkLobbyGui.ColorSwitchClick();
            };
        }

        public NetworkLobbyGui GetNetworkLobbyGui()
        {
            return _networkLobbyGui;
        }

        public void SetMyPlayerId(int myPlayerId)
        {
            _myPlayerId = myPlayerId;
        }

        public void UpdateLobbyPlayers(List<Game.Lobby.LobbyPlayer> lobbyPlayers)
        {
            this.InvokeIfRequired(() =>
            {
                var player1 = lobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position1);
                if (player1 != null)
                    lobbyPlayer1.SetLobbyPlayer(player1, player1.PlayerId == _myPlayerId);
                else
                    lobbyPlayer1.SetEmpty();

                var player2 = lobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position2);
                if (player2 != null)
                    lobbyPlayer2.SetLobbyPlayer(player2, player2.PlayerId == _myPlayerId);
                else
                    lobbyPlayer2.SetEmpty();

                var player3 = lobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position3);
                if (player3 != null)
                    lobbyPlayer3.SetLobbyPlayer(player3, player3.PlayerId == _myPlayerId);
                else
                    lobbyPlayer3.SetEmpty();

                var player4 = lobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position4);
                if (player4 != null)
                    lobbyPlayer4.SetLobbyPlayer(player4, player4.PlayerId == _myPlayerId);
                else
                    lobbyPlayer4.SetEmpty();

                var player5 = lobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position5);
                if (player5 != null)
                    lobbyPlayer5.SetLobbyPlayer(player5, player5.PlayerId == _myPlayerId);
                else
                    lobbyPlayer5.SetEmpty();

                var player6 = lobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position6);
                if (player6 != null)
                    lobbyPlayer6.SetLobbyPlayer(player6, player6.PlayerId == _myPlayerId);
                else
                    lobbyPlayer6.SetEmpty();

                var spectators = lobbyPlayers.Where(x => x.PlayerPosition == PlayerPosition.Spectator);
                var areSpectatorsEmpty = true;
                var spectatorsSb = new StringBuilder();
                foreach (var spectator in spectators)
                {
                    if (!areSpectatorsEmpty)
                        spectatorsSb.Append(", ");

                    spectatorsSb.Append(spectator.PlayerName);
                    areSpectatorsEmpty = false;
                }

                labelSpectatorsList.Text = spectatorsSb.ToString();
            });
        }

        public void ShowLobbyException(string message)
        {
            this.InvokeIfRequired(() =>
                {
                    MessageBox.Show(message, "Chyba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                });
        }

        public void CloseLobby()
        {
            this.InvokeIfRequired(this.Close);
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

        private void FormNetworkLobby_FormClosed(object sender, FormClosedEventArgs e)
        {
            _networkLobbyGui.LobbyClosed();
        }

        private void buttonJoinSpectators_Click(object sender, EventArgs e)
        {
            _networkLobbyGui.JoinSpectatorsClick();
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
            _networkLobbyGui.ChatSendMessageClick(message);
        }
    }
}
