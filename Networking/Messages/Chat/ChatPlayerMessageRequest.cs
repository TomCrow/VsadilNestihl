using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.Networking.Messages.Chat
{
    [Serializable]
    public class ChatPlayerMessageRequest : IMessage
    {
        public string Message { get; set; }

        public ChatPlayerMessageRequest() { }
        public ChatPlayerMessageRequest(string message)
        {
            Message = message;
        }
    }
}
