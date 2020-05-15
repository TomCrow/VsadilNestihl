using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Lobby
{
    [Serializable]
    public class LobbyActionException : IMessage
    {
        public string Message { get; set; }

        public LobbyActionException() { }
        public LobbyActionException(string message)
        {
            Message = message;
        }
    }
}
