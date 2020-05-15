using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Lobby
{
    [Serializable]
    public class PlayerPositionSwitchRequest : IMessage
    {
        public int PlayerPosition { get; set; }

        public PlayerPositionSwitchRequest() { }
        public PlayerPositionSwitchRequest(int playerPosition)
        {
            PlayerPosition = playerPosition;
        }
    }
}
