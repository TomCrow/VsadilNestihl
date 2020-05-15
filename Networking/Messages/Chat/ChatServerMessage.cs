using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Chat
{
    [Serializable]
    public class ChatServerMessage : IMessage
    {
        public string Message { get; set; }

        public ChatServerMessage() { }
        public ChatServerMessage(string message)
        {
            Message = message;
        }
    }
}
