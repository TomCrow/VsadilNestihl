using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Player;
using VsadilNestihlNetworking.Messages;
using VsadilNestihlNetworking.Messages.Chat;
using VsadilNestihlNetworking.Messages.Game;
using VsadilNestihlNetworking.Messages.Lobby;

namespace VsadilNestihl.Game.Network
{
    public class GameClient
    {
        private VsadilNestihlNetworking.Client _client;

        public List<IMessage> ChatMessages { get; private set; } = new List<IMessage>();
        public bool StoreChatMessages { get; set; } = true;

        public event Action Disconnected;

        // Lobby
        public event Action<LobbyActionException> LobbyException;
        public event Action<SetPlayerId> SetMyPlayerId;
        public event Action<LobbyPlayersUpdate> LobbyPlayersUpdated;
        public event Action<GameStarting> GameStarting;

        // Chat
        public event Action<ChatServerMessage> ChatServerMessage;
        public event Action<ChatPlayerMessage> ChatPlayerMessage;

        // Game
        public event Action<GameActionException> GameActionException;
        public event Action<GameStarted> GameStarted;
        public event Action<PlayerSetMoney> PlayerSetMoney;
        public event Action<PlayerRolledDice> PlayerRolledDice;
        public event Action<PlayerRolledThisTurn> PlayerRolledThisTurn;
        public event Action<PlayerSetPlace> PlayerSetPlace;
        public event Action<NextRound> NextRound;

        public GameClient() { }

        public void Join(string playerName, string ip, int port)
        {
            if (_client != null)
                return;

            _client = new VsadilNestihlNetworking.Client(new VsadilNestihlNetworking.SerializationEngines.IdJsonSerialization());

            _client.OnDisonnected += ClientOnOnDisonnected;

            // Lobby
            _client.MessageDispatcher.Add(typeof(LobbyActionException), OnLobbyActionException);
            _client.MessageDispatcher.Add(typeof(SetPlayerId), OnSetPlayerId);
            _client.MessageDispatcher.Add(typeof(LobbyPlayersUpdate), OnLobbyPlayersUpdate);
            _client.MessageDispatcher.Add(typeof(ChatServerMessage), OnChatServerMessage);
            _client.MessageDispatcher.Add(typeof(ChatPlayerMessage), OnChatPlayerMessage);
            _client.MessageDispatcher.Add(typeof(GameStarting), OnGameStarting);

            // Game
            _client.MessageDispatcher.Add(typeof(GameActionException), OnGameActionException);
            _client.MessageDispatcher.Add(typeof(GameStarted), OnGameStarted);
            _client.MessageDispatcher.Add(typeof(PlayerSetMoney), OnPlayerSetMoney );
            _client.MessageDispatcher.Add(typeof(PlayerRolledDice), OnPlayerRolledDice );
            _client.MessageDispatcher.Add(typeof(PlayerRolledThisTurn), OnPlayerRolledThisTurn );
            _client.MessageDispatcher.Add(typeof(PlayerSetPlace), OnPlayerSetPlace);
            _client.MessageDispatcher.Add(typeof(NextRound), OnNextRound);

            _client.Connect(ip, port);
            _client.SendMessage(new PlayerJoinRequest(playerName));
        }

        public void SendMessage(IMessage message)
        {
            _client.SendMessage(message);
        }

        public void DisconnectPlayer()
        {
            _client.SendMessage(new Disconnect());
        }

        public void LobbyPositionSwitchRequest(PlayerPosition playerPosition)
        {
            _client.SendMessage(new PlayerPositionSwitchRequest((int)playerPosition));
        }

        public void LobbyColorSwitchRequest()
        {
            _client.SendMessage(new PlayerColorSwitchRequest());
        }

        public void ChatSendMessageRequest(string message)
        {
            _client.SendMessage(new ChatPlayerMessageRequest(message));
        }

        private void ClientOnOnDisonnected(object sender, EventArgs e)
        {
            Disconnected?.Invoke();
        }

        private void OnLobbyActionException(IMessage message)
        {
            if (!(message is LobbyActionException lobbyActionException))
                return;

            LobbyException?.Invoke(lobbyActionException);
        }

        private void OnSetPlayerId(IMessage message)
        {
            if (!(message is SetPlayerId setPlayerId))
                return;
            
            SetMyPlayerId?.Invoke(setPlayerId);
        }

        private void OnLobbyPlayersUpdate(IMessage message)
        {
            if (!(message is LobbyPlayersUpdate lobbyPlayersUpdate))
                return;
            
            LobbyPlayersUpdated?.Invoke(lobbyPlayersUpdate);
        }

        private void OnChatServerMessage(IMessage message)
        {
            if (!(message is ChatServerMessage chatServerMessage))
                return;

            if (StoreChatMessages)
                ChatMessages.Add(chatServerMessage);

            ChatServerMessage?.Invoke(chatServerMessage);
        }

        private void OnChatPlayerMessage(IMessage message)
        {
            if (!(message is ChatPlayerMessage chatPlayerMessage))
                return;
            
            if (StoreChatMessages)
                ChatMessages.Add(chatPlayerMessage);

            ChatPlayerMessage?.Invoke(chatPlayerMessage);
        }

        private void OnGameStarting(IMessage message)
        {
            if (!(message is GameStarting gameStarting))
                return;

            GameStarting?.Invoke(gameStarting);
        }

        private void OnGameActionException(IMessage message)
        {
            if (!(message is GameActionException gameActionException))
                return;

            GameActionException?.Invoke(gameActionException);
        }

        private void OnGameStarted(IMessage message)
        {
            if (!(message is GameStarted gameStarted))
                return;

            GameStarted?.Invoke(gameStarted);
        }

        private void OnPlayerSetMoney(IMessage message)
        {
            if (!(message is PlayerSetMoney playerSetMoney))
                return;

            PlayerSetMoney?.Invoke(playerSetMoney);
        }
        private void OnPlayerRolledDice(IMessage message)
        {
            if (!(message is PlayerRolledDice playerRolledDice))
                return;

            PlayerRolledDice?.Invoke(playerRolledDice);
        }

        private void OnPlayerRolledThisTurn(IMessage message)
        {
            if (!(message is PlayerRolledThisTurn playerRolledThisTurn))
                return;

            PlayerRolledThisTurn?.Invoke(playerRolledThisTurn);
        }

        private void OnPlayerSetPlace(IMessage message)
        {
            if (!(message is PlayerSetPlace playerSetPlace))
                return;

            PlayerSetPlace?.Invoke(playerSetPlace);
        }
        private void OnNextRound(IMessage message)
        {
            if (!(message is NextRound nextRound))
                return;

            NextRound?.Invoke(nextRound);
        }
    }
}
