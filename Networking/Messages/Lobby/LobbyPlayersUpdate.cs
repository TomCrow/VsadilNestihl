using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Lobby
{
    [Serializable]
    public class LobbyPlayersUpdate : IMessage
    {
        public List<LobbyPlayer> LobbyPlayers { get; set; }

        public LobbyPlayersUpdate() { }
        public LobbyPlayersUpdate(List<LobbyPlayer> lobbyPlayers)
        {
            LobbyPlayers = lobbyPlayers;
        }
    }
}
