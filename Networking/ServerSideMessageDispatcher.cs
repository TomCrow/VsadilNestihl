using System;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking
{
    class ServerSideMessageDispatcher<T> : IServerSideMessageDispatcher
        where T : IMessage
    {
        public event Action<T, Receiver> MessageReceived;

        public void Dispatch(IMessage message, Receiver receiver)
        {
            if (!(message is T))
                throw new InvalidCastException($"Message is not type of {typeof(T)}");

            dynamic dynamicMessage = message;
            Dispatch(dynamicMessage, receiver);
        }

        public void Dispatch(T message, Receiver receiver)
        {
            MessageReceived?.Invoke(message, receiver);
        }
    }
}