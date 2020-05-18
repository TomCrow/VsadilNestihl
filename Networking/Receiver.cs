using System;
using System.Collections.Generic;
using System.Net.Sockets;
using System.Threading;
using VsadilNestihl.Networking.Messages;

namespace VsadilNestihl.Networking
{
    public class Receiver
    {
        private Thread _receivingThread;
        private Thread _sendingThread;
        private readonly Dictionary<Type, IServerSideMessageDispatcher> _messageDispatchers;

        public Guid ID { get; set; }
        public Server Server { get; private set; }
        public TcpClient Client { get; private set; }
        public bool Connected { get; private set; }
        public List<Messages.IMessage> MessageQueue { get; private set; }
        public long TotalBytesUsage { get; set; }
        public int SendingInterval { get; set; }
        public int ReceivingInterval { get; set; }
        public int HeartbeatInterval { get; set; }
        public int MaxMessageSize { get; set; }

        private event EventHandler NoticeServerMyDisconnection;

        private Receiver()
        {
            _messageDispatchers = new Dictionary<Type, IServerSideMessageDispatcher>();

            ID = Guid.NewGuid();
            MessageQueue = new List<Messages.IMessage>();
            Connected = true;
            SendingInterval = 30;
            ReceivingInterval = 30;
            HeartbeatInterval = 3000;
            MaxMessageSize = 10000000;
        }

        public Receiver(TcpClient client, Server server, EventHandler noticeDisconnection)
            : this()
        {
            Server = server;
            Client = client;

            NoticeServerMyDisconnection += noticeDisconnection;

            //Client.ReceiveBufferSize = 1024;
            //Client.SendBufferSize = 1024;
        }

        #region Methods

        public void Start()
        {
            _receivingThread = new Thread(ReceivingMethod);
            _receivingThread.IsBackground = true;
            _receivingThread.Start();

            _sendingThread = new Thread(SendingMethod);
            _sendingThread.IsBackground = true;
            _sendingThread.Start();
        }

        public void Disconnect()
        {
            // TODO: tady breakpoint - zamrznuti pri opakovanem pripojeni do lobby
            if (Connected == false) return;
            Connected = false;

            try
            {
                Client.Client.Disconnect(false);
                Client.Close();
            }
            catch (Exception) { }

            NoticeServerMyDisconnection?.Invoke(this, EventArgs.Empty);
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

        public void SendMessage(Messages.IMessage message)
        {
            MessageQueue.Add(message);
        }

        #endregion

        #region Threads Methods

        private void SendingMethod()
        {
            DateTime LastHearbeatSent = DateTime.Now;
            while (Connected)
            {
                if (MessageQueue.Count > 0)
                {
                    var message = MessageQueue[0];

                    try
                    {
                        byte[] data = Server.SerializationEngine.Serialize(message);
                        byte[] framed = new byte[data.Length + 4];

                        framed[0] = (byte)(data.Length);
                        framed[1] = (byte)(data.Length >> 8);
                        framed[2] = (byte)(data.Length >> 16);
                        framed[3] = (byte)(data.Length >> 24);

                        data.CopyTo(framed, 4);

                        Client.GetStream().Write(framed, 0, framed.Length);
                        Client.GetStream().Flush();
                    }
                    catch (Exception)
                    {
                        Disconnect();
                    }
                    finally
                    {
                        MessageQueue.Remove(message);
                    }
                }

                // Heartbeat
                double LastHearbeatInMs = (DateTime.Now - LastHearbeatSent).TotalMilliseconds;
                if (LastHearbeatInMs > HeartbeatInterval)
                {
                    SendMessage(new Messages.Heartbeat());
                    LastHearbeatSent = DateTime.Now;
                }

                Thread.Sleep(SendingInterval);
            }
        }


        private void ReceivingMethod()
        {
            byte[] frame = new byte[4];
            int framePosition = 0;
            int frameSize = 0;

            byte[] data = new byte[0];
            int dataPosition = 0;

            while (Connected)
            {
                if (Client.Available > 0)
                {
                    TotalBytesUsage += Client.Available;

                    try
                    {
                        NetworkStream stream = Client.GetStream();
                        byte[] inbuffer = new byte[Client.ReceiveBufferSize];

                        if (stream.CanRead)
                        {
                            do
                            {
                                if (framePosition < 3)
                                {
                                    int bytesRead = stream.Read(frame, framePosition, 4 - framePosition);
                                    framePosition = framePosition + bytesRead;

                                    if (framePosition > 3)
                                    {
                                        frameSize |= frame[0];
                                        frameSize |= (((int)frame[1]) << 8);
                                        frameSize |= (((int)frame[2]) << 16);
                                        frameSize |= (((int)frame[3]) << 24);

                                        if (frameSize > MaxMessageSize)
                                        {
                                            Disconnect();
                                            break;
                                        }

                                        if (frameSize == 0) // Heartbeat
                                        {
                                            frame = new byte[4];
                                            framePosition = 0;
                                        }

                                        // reset data
                                        data = new byte[frameSize];
                                        dataPosition = 0;
                                    }
                                }
                                else
                                {
                                    int bytesRead = stream.Read(data, dataPosition, frameSize - dataPosition);
                                    dataPosition = dataPosition + bytesRead;

                                    if (dataPosition >= frameSize)
                                    {
                                        Messages.IMessage message = Server.SerializationEngine.Deserialize(data);

                                        if (message is Messages.Disconnect)
                                        {
                                            Disconnect();
                                            break;
                                        }

                                        // global message dispatcher
                                        if (Server.GetMessageDispatchers().ContainsKey(message.GetType()))
                                            Server.GetMessageDispatchers()[message.GetType()].Dispatch(message, this);

                                        // local message dispatcher
                                        if (_messageDispatchers.ContainsKey(message.GetType()))
                                            _messageDispatchers[message.GetType()].Dispatch(message, this);

                                        // reset frame and data
                                        frame = new byte[4];
                                        framePosition = 0;
                                        frameSize = 0;

                                        data = new byte[0];
                                        dataPosition = 0;
                                    }
                                }
                            } while (stream.DataAvailable);
                        }
                    }
                    catch (Exception)
                    {
                        Disconnect();
                    }
                }

                Thread.Sleep(ReceivingInterval);
            }

        }

        #endregion
    }
}
