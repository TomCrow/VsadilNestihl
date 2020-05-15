using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Lobby
{
    [Serializable]
    public class SetPlayerId : IMessage
    {
        public int PlayerId { get; set; }

        public SetPlayerId() { }
        public SetPlayerId(int playerId)
        {
            PlayerId = playerId;
        }
    }
}
