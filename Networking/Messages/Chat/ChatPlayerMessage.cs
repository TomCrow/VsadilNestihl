using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Chat
{
    [Serializable]
    public class ChatPlayerMessage : IMessage
    {
        public int PlayerId { get; set; }
        public string Message { get; set; }

        public ChatPlayerMessage() { }
        public ChatPlayerMessage(int playerId, string message)
        {
            PlayerId = playerId;
            Message = message;
        }
    }
}
