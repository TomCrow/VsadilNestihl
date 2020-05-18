using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking
{
    class ClientSideMessageDispatcher<T> : IClientSideMessageDispatcher
        where T : IMessage
    {
        public event Action<T> MessageReceived;
        
        public void Dispatch(IMessage message)
        {
            if (!(message is T))
                throw new InvalidCastException($"Message is not type of {typeof(T)}");

            dynamic dynamicMessage = message;
            Dispatch(dynamicMessage);
        }
        
        public void Dispatch(T message)
        {
            MessageReceived?.Invoke(message);
        }
    }
}
