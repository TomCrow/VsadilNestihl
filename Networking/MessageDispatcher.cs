using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking
{
    class MessageDispatcher<T> : IMessageDispatcher
        where T : IMessage
    {
        public event Action<T> MessageReceived;
        
        public void Dispatch(IMessage message)
        {
            Dispatch(message as T);
        }
        
        public void Dispatch(T message)
        {
            MessageReceived?.Invoke(message);
        }
    }
}
