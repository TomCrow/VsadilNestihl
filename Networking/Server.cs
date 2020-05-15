using System;
using System.Collections.Generic;
using System.Net.Sockets;

namespace VsadilNestihl.Networking
{
    public class Server
    {
        public TcpListener Listener { get; set; }
        public int Port { get; set; }
        public bool IsStarted { get; private set; }
        private List<Receiver> Receivers { get; set; }

        private readonly object ReceiversLock = new object();

        public SerializationEngines.ISerializationEngine SerializationEngine { get; private set; }

        public delegate void IncomingMessage(Messages.IMessage message, Receiver receiver);
        public Dictionary<Type, IncomingMessage> MessageDispatcher { get; private set; }


        #region Events

        public event EventHandler<Receiver> OnClientConnected;
        public event EventHandler<Receiver> OnClientDisonnected;

        #endregion

        #region Constructors

        public Server(int port, SerializationEngines.ISerializationEngine serializationEngine)
        {
            lock (ReceiversLock)
                Receivers = new List<Receiver>();

            Port = port;
            this.SerializationEngine = serializationEngine;
            this.MessageDispatcher = new Dictionary<Type, IncomingMessage>();
        }

        #endregion

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
