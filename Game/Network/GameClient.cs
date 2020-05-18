using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Networking.Messages;
using VsadilNestihl.Networking.Messages.Chat;
using VsadilNestihl.Networking.Messages.Game;
using VsadilNestihl.Networking.Messages.Lobby;

namespace VsadilNestihl.Game.Network
{
    public class GameClient
    {
        private VsadilNestihl.Networking.Client _client;

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
        public event Action<PlayerPassedPlace> PlayerPassedPlace;
        public event Action<PlayerSetPlace> PlayerSetPlace;
        public event Action<NextRound> NextRound;

        public GameClient() { }

        public void Join(string playerName, string ip, int port)
        {
            if (_client != null)
                return;

            _client = new VsadilNestihl.Networking.Client(new VsadilNestihl.Networking.SerializationEngines.IdJsonSerialization());

            _client.OnDisonnected += ClientOnOnDisonnected;

            // Lobby
            _client.SubscribeForMessage<LobbyActionException>(OnLobbyActionException);
            _client.SubscribeForMessage<SetPlayerId>(OnSetPlayerId);
            _client.SubscribeForMessage<LobbyPlayersUpdate>(OnLobbyPlayersUpdate);
            _client.SubscribeForMessage<ChatServerMessage>(OnChatServerMessage);
            _client.SubscribeForMessage<ChatPlayerMessage>(OnChatPlayerMessage);
            _client.SubscribeForMessage<GameStarting>(OnGameStarting);

            // Game
            _client.SubscribeForMessage<GameActionException>(OnGameActionException);
            _client.SubscribeForMessage<GameStarted>(OnGameStarted);
            _client.SubscribeForMessage<PlayerSetMoney>(OnPlayerSetMoney);
            _client.SubscribeForMessage<PlayerRolledDice>(OnPlayerRolledDice);
            _client.SubscribeForMessage<PlayerRolledThisTurn>(OnPlayerRolledThisTurn);
            _client.SubscribeForMessage<PlayerPassedPlace>(OnPlayerPassedPlace);
            _client.SubscribeForMessage<PlayerSetPlace>(OnPlayerSetPlace);
            _client.SubscribeForMessage<NextRound>(OnNextRound);

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

        private void OnLobbyActionException(LobbyActionException lobbyActionException)
        {
            LobbyException?.Invoke(lobbyActionException);
        }

        private void OnSetPlayerId(SetPlayerId setPlayerId)
        {
            SetMyPlayerId?.Invoke(setPlayerId);
        }

        private void OnLobbyPlayersUpdate(LobbyPlayersUpdate lobbyPlayersUpdate)
        {
            LobbyPlayersUpdated?.Invoke(lobbyPlayersUpdate);
        }

        private void OnChatServerMessage(ChatServerMessage chatServerMessage)
        {
            if (StoreChatMessages)
                ChatMessages.Add(chatServerMessage);

            ChatServerMessage?.Invoke(chatServerMessage);
        }

        private void OnChatPlayerMessage(ChatPlayerMessage chatPlayerMessage)
        {
            if (StoreChatMessages)
                ChatMessages.Add(chatPlayerMessage);

            ChatPlayerMessage?.Invoke(chatPlayerMessage);
        }

        private void OnGameStarting(GameStarting gameStarting)
        {
            GameStarting?.Invoke(gameStarting);
        }

        private void OnGameActionException(GameActionException gameActionException)
        {
            GameActionException?.Invoke(gameActionException);
        }

        private void OnGameStarted(GameStarted gameStarted)
        {
            GameStarted?.Invoke(gameStarted);
        }

        private void OnPlayerSetMoney(PlayerSetMoney playerSetMoney)
        {
            PlayerSetMoney?.Invoke(playerSetMoney);
        }
        private void OnPlayerRolledDice(PlayerRolledDice playerRolledDice)
        {
            PlayerRolledDice?.Invoke(playerRolledDice);
        }

        private void OnPlayerRolledThisTurn(PlayerRolledThisTurn playerRolledThisTurn)
        {
            PlayerRolledThisTurn?.Invoke(playerRolledThisTurn);
        }

        private void OnPlayerPassedPlace(PlayerPassedPlace playerPassedPlace)
        {
            PlayerPassedPlace?.Invoke(playerPassedPlace);
        }

        private void OnPlayerSetPlace(PlayerSetPlace playerSetPlace)
        {
            PlayerSetPlace?.Invoke(playerSetPlace);
        }
        private void OnNextRound(NextRound nextRound)
        {
            NextRound?.Invoke(nextRound);
        }
    }
}
