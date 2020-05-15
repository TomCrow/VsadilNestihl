using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Lobby
{
    public class LobbyPlayer
    {
        public int PlayerId { get; set; }
        public string PlayerName { get; set; }
        public int Color { get; set; }
        public int PlayerPosition { get; set; }

        public LobbyPlayer() { }
        public LobbyPlayer(int playerId, string playerName, int color, int playerPosition)
        {
            PlayerId = playerId;
            PlayerName = playerName;
            Color = color;
            PlayerPosition = playerPosition;
        }
    }
}
