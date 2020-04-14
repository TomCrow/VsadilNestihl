using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace VsadilNestihl.GUI.NetworkLobby
{
    public interface INetworkLobbyView
    {
        NetworkLobbyGui GetNetworkLobbyGui();
        void SetMyPlayerId(int myPlayerId);
        void UpdateLobbyPlayers(List<Game.Lobby.LobbyPlayer> lobbyPlayers);
        void ShowLobbyException(string message);
        void CloseLobby();
        void AddChatMessage(string message);
    }
}
