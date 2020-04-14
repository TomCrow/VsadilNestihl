using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihlNetworking.Messages;
using VsadilNestihlNetworking.Messages.Lobby;
using VsadilNestihlNetworking.SerializationEngines;

namespace VsadilNestihl.Game.Lobby
{
    public class JoiningPlayer
    {
        private VsadilNestihlNetworking.Client _client;
        private int _myPlayerId = 0;
        private List<LobbyPlayer> _lobbyPlayers = null;

        public List<IMessage> ChatMessages { get; private set; } = new List<IMessage>();
        public bool StoreChatMessages { get; set; } = true;

        public event Action<string> LobbyException;
        public event Action<int> SetMyPlayerId;
        public event Action<List<LobbyPlayer>> LobbyPlayersUpdated;
        public event Action<string> ChatServerMessage;
        public event Action<LobbyPlayer, string> ChatPlayerMessage;
        public event Action Disconnected;

        public JoiningPlayer() { }

        public void Join(string playerName, string ip, int port)
        {
            if (_client != null)
                return;

            _client = new VsadilNestihlNetworking.Client(new IdJsonSerialization());

            _client.OnDisonnected += ClientOnOnDisonnected;
            _client.MessageDispatcher.Add(typeof(LobbyActionException), OnLobbyActionException);
            _client.MessageDispatcher.Add(typeof(SetPlayerId), OnSetPlayerId);
            _client.MessageDispatcher.Add(typeof(LobbyPlayersUpdate), OnLobbyPlayersUpdate);
            _client.MessageDispatcher.Add(typeof(VsadilNestihlNetworking.Messages.Chat.ChatServerMessage), OnChatServerMessage);
            _client.MessageDispatcher.Add(typeof(VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessage), OnChatPlayerMessage);

            _client.Connect(ip, port);
            _client.SendMessage(new PlayerJoinRequest(playerName));
        }
        
        public void DisconnectPlayer()
        {
            _client.SendMessage(new Disconnect());
        }

        public int GetMyPlayerId()
        {
            return _myPlayerId;
        }

        public List<LobbyPlayer> GetLobbyPlayers()
        {
            return _lobbyPlayers;
        }

        public void PositionSwitchRequest(PlayerPosition playerPosition)
        {
            _client.SendMessage(new PlayerPositionSwitchRequest((int)playerPosition));
        }

        public void ColorSwitchRequest()
        {
            _client.SendMessage(new PlayerColorSwitchRequest());
        }

        public void ChatSendMessageRequest(string message)
        {
            _client.SendMessage(new VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessageRequest(message));
        }

        private void ClientOnOnDisonnected(object sender, EventArgs e)
        {
            Disconnected?.Invoke();
        }

        private void OnLobbyActionException(IMessage message)
        {
            if (!(message is LobbyActionException lobbyActionException))
                return;

            LobbyException?.Invoke(lobbyActionException.Message);
        }

        private void OnSetPlayerId(IMessage message)
        {
            if (!(message is SetPlayerId setPlayerId))
                return;

            _myPlayerId = setPlayerId.PlayerId;
            SetMyPlayerId?.Invoke(_myPlayerId);
        }

        private void OnLobbyPlayersUpdate(IMessage message)
        {
            if (!(message is LobbyPlayersUpdate lobbyPlayersUpdate))
                return;

            var lobbyPlayers = new List<LobbyPlayer>();
            foreach (var lobbyPlayer in lobbyPlayersUpdate.LobbyPlayers)
            {
                lobbyPlayers.Add(new LobbyPlayer(lobbyPlayer.PlayerId, lobbyPlayer.PlayerName,
                    Color.FromArgb(lobbyPlayer.Color), (PlayerPosition) lobbyPlayer.PlayerPosition));
            }

            _lobbyPlayers = lobbyPlayers;
            LobbyPlayersUpdated?.Invoke(lobbyPlayers);
        }

        private void OnChatServerMessage(IMessage message)
        {
            if (!(message is VsadilNestihlNetworking.Messages.Chat.ChatServerMessage chatServerMessage))
                return;

            if (StoreChatMessages)
                ChatMessages.Add(chatServerMessage);

            ChatServerMessage?.Invoke(chatServerMessage.Message);
        }

        private void OnChatPlayerMessage(IMessage message)
        {
            if (!(message is VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessage chatPlayerMessage))
                return;

            var lobbyPlayer = _lobbyPlayers.Find(x => x.PlayerId == chatPlayerMessage.PlayerId);
            if (lobbyPlayer == null)
                return;

            if (StoreChatMessages)
                ChatMessages.Add(chatPlayerMessage);

            ChatPlayerMessage?.Invoke(lobbyPlayer, chatPlayerMessage.Message);
        }
    }
}
