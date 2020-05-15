using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Lobby
{
    [Serializable]
    public class PlayerJoinRequest : IMessage
    {
        public string PlayerName { get; set; }

        public PlayerJoinRequest() { }
        public PlayerJoinRequest(string playerName)
        {
            PlayerName = playerName;
        }
    }
}
