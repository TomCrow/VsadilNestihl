using System;
using System.Collections.Generic;
using System.Net.Sockets;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking
{
    public class Server
    {
        private readonly Dictionary<Type, IServerSideMessageDispatcher> _messageDispatchers;

        public TcpListener Listener { get; set; }
        public int Port { get; set; }
        public bool IsStarted { get; private set; }
        private List<Receiver> Receivers { get; set; }

        private readonly object ReceiversLock = new object();

        public SerializationEngines.ISerializationEngine SerializationEngine { get; private set; }


        #region Events

        public event EventHandler<Receiver> OnClientConnected;
        public event EventHandler<Receiver> OnClientDisonnected;

        #endregion

        #region Constructors

        public Server(int port, SerializationEngines.ISerializationEngine serializationEngine)
        {
            _messageDispatchers = new Dictionary<Type, IServerSideMessageDispatcher>();

            lock (ReceiversLock)
                Receivers = new List<Receiver>();

            Port = port;
            this.SerializationEngine = serializationEngine;
        }

        #endregion

        internal Dictionary<Type, IServerSideMessageDispatcher> GetMessageDispatchers()
        {
            return _messageDispatchers;
        }

        #region Public Methods
        public void Start()
        {
            if (!IsStarted)
            {
                Listener = new TcpListener(System.Net.IPAddress.Any, Port);
                Listener.Start();
                IsStarted = true;
                WaitForConnection();
            }
        }

        public void Stop()
        {
            if (IsStarted)
            {
                IsStarted = false;
                Listener.Stop();

                for (int i = Receivers.Count - 1; i >= 0; --i)
                    Receivers[i].Disconnect();

                Receivers.Clear();
            }
        }

        public void SubscribeForMessage<T>(Action<T, Receiver> messageReceived)
            where T : IMessage
        {
            if (!_messageDispatchers.ContainsKey(typeof(T)))
                _messageDispatchers.Add(typeof(T), new ServerSideMessageDispatcher<T>());

            var dispatcher = _messageDispatchers[typeof(T)] as ServerSideMessageDispatcher<T>;
            if (dispatcher == null)
                throw new InvalidCastException(nameof(dispatcher));

            dispatcher.MessageReceived += messageReceived;
        }

        public void UnsubscribeFromMessage<T>(Action<T, Receiver> messageReceived)
            where T : IMessage
        {
            if (!_messageDispatchers.ContainsKey(typeof(T)))
                return;

            var dispatcher = _messageDispatchers[typeof(T)] as ServerSideMessageDispatcher<T>;
            if (dispatcher == null)
                throw new InvalidCastException(nameof(dispatcher));

            dispatcher.MessageReceived -= messageReceived;
        }

        public void Broadcast(Messages.IMessage message)
        {
            lock (ReceiversLock)
            {
                foreach (Receiver receiver in Receivers)
                    receiver.SendMessage(message);
            }
        }

        #endregion

        #region Private Methods

        private void ClientDisconnected(object sender, EventArgs args)
        {
            Receiver client = sender as Receiver;
            if (client != null)
            {
                lock (ReceiversLock)
                    Receivers.Remove(client);

                OnClientDisonnected?.Invoke(this, client);
            }
        }

        #endregion

        #region Incoming Connections Methods

        private void WaitForConnection()
        {
            Listener.BeginAcceptTcpClient(new AsyncCallback(ConnectionHandler), null);
        }

        private void ConnectionHandler(IAsyncResult ar)
        {
            if (!IsStarted) return;

            lock (ReceiversLock)
            {
                try
                {
                    Receiver client = new Receiver(Listener.EndAcceptTcpClient(ar), this, ClientDisconnected);
                    client.Start();
                    Receivers.Add(client);
                    OnClientConnected?.Invoke(this, client);
                }
                catch (ObjectDisposedException) { }
            }

            WaitForConnection();
        }

        #endregion
    }
}
