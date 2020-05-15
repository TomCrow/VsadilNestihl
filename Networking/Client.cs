using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using VsadilNestihl.Networking.Messages.Game;

namespace VsadilNestihl.Networking
{
    public class Client
    {
        private Thread receivingThread;
        private Thread sendingThread;

        public TcpClient TcpClient { get; private set; }
        public String Address { get; private set; }
        public int Port { get; private set; }
        public bool Connected { get; private set; }
        public List<Messages.IMessage> MessageQueue { get; private set; }
        public long TotalBytesUsage { get; set; }
        public int SendingInterval { get; set; }
        public int ReceivingInterval { get; set; }
        public int HeartbeatInterval { get; set; }
        public int MaxMessageSize { get; set; }

        public SerializationEngines.ISerializationEngine SerializationEngine { get; private set; }

        public delegate void IncomingMessage(Messages.IMessage message);
        public Dictionary<Type, IncomingMessage> MessageDispatcher { get; private set; }

        #region Events

        public event EventHandler OnDisonnected;

        #endregion

        #region Constructors

        public Client(SerializationEngines.ISerializationEngine serializationEngine)
        {
            MessageQueue = new List<Messages.IMessage>();
            Connected = false;
            SendingInterval = 30;
            ReceivingInterval = 30;
            HeartbeatInterval = 3000;
            MaxMessageSize = 10000;

            this.SerializationEngine = serializationEngine;
            MessageDispatcher = new Dictionary<Type, IncomingMessage>();
        }

        #endregion

        #region Methods

        public void Connect(string address, int port)
        {
            Address = address;
            Port = port;
            TcpClient = new TcpClient();
            TcpClient.Connect(Address, Port);
            //TcpClient.ReceiveBufferSize = 1024;
            //TcpClient.SendBufferSize = 1024;

            MessageQueue.Clear();


            Connected = true;

            receivingThread = new Thread(ReceivingMethod);
            receivingThread.IsBackground = true;
            receivingThread.Start();

            sendingThread = new Thread(SendingMethod);
            sendingThread.IsBackground = true;
            sendingThread.Start();
        }

        public void Disconnect()
        {
            if (Connected == false) return;

            MessageQueue.Clear();
            SendMessage(new Messages.Disconnect());

            try
            {
                TcpClient.Client.Disconnect(false);
                TcpClient.Close();
            }
            catch (ObjectDisposedException) { }
            catch (SocketException) { }

            Connected = false;
            OnDisonnected?.Invoke(this, EventArgs.Empty);
        }

        public void SendMessage(Messages.IMessage message)
        {
            MessageQueue.Add(message);
        }

        #endregion

        #region Threads Methods

        private void SendingMethod(object obj)
        {
            DateTime LastHearbeatSent = DateTime.Now;
            while (Connected)
            {
                if (MessageQueue.Count > 0)
                {
                    var message = MessageQueue[0];

                    try
                    {
                        byte[] data = SerializationEngine.Serialize(message);
                        byte[] framed = new byte[data.Length + 4];

                        framed[0] = (byte) (data.Length);
                        framed[1] = (byte) (data.Length >> 8);
                        framed[2] = (byte) (data.Length >> 16);
                        framed[3] = (byte) (data.Length >> 24);

                        data.CopyTo(framed, 4);

                        TcpClient.GetStream().Write(framed, 0, framed.Length);
                        TcpClient.GetStream().Flush();
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

        private void ReceivingMethod(object obj)
        {
            byte[] frame = new byte[4];
            int framePosition = 0;
            int frameSize = 0;

            byte[] data = new byte[0];
            int dataPosition = 0;

            while (Connected)
            {
                try
                {
                    if (TcpClient.Available > 0)
                    {
                        TotalBytesUsage += TcpClient.Available;

                        NetworkStream stream = TcpClient.GetStream();
                        byte[] inbuffer = new byte[TcpClient.ReceiveBufferSize];

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
                                        Messages.IMessage message = SerializationEngine.Deserialize(data);

                                        if (message is Messages.Disconnect)
                                        {
                                            Disconnect();
                                            break;
                                        }

                                        // local message dispatcher
                                        if (MessageDispatcher.ContainsKey(message.GetType()))
                                            MessageDispatcher[message.GetType()]?.Invoke((message));

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
                }
                catch (Exception)
                {
                    Disconnect();
                    break;
                }

                Thread.Sleep(ReceivingInterval);
            }
        }

        #endregion
    }
}
