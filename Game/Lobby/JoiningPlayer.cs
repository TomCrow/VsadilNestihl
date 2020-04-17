using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Network;
using VsadilNestihl.Game.Player;
using VsadilNestihlNetworking.Messages;
using VsadilNestihlNetworking.Messages.Lobby;
using VsadilNestihlNetworking.SerializationEngines;

namespace Playeyr
{
    public class JoiningPlayer
    {
        private GameClient _gameClient;
        private int _myPlayerId = 0;
        private List<LobbyPlayer> _lobbyPlayers = null;

        public event Action Disconnected;
        public event Action<string> LobbyException;
        public event Action<int> SetMyPlayerId;
        public event Action<List<LobbyPlayer>> LobbyPlayersUpdated;
        public event Action<string> ChatServerMessage;
        public event Action<LobbyPlayer, string> ChatPlayerMessage;
        public event Action<RemoteGame> GameStarting;

        public JoiningPlayer() { }

        public void Join(string playerName, string ip, int port)
        {
            if (_gameClient != null)
                return;

            _gameClient = new GameClient();
            _gameClient.Disconnected += () => Disconnected?.Invoke();
            _gameClient.LobbyException += GameClientOnLobbyException;
            _gameClient.SetMyPlayerId += GameClientOnSetMyPlayerId;
            _gameClient.LobbyPlayersUpdated += GameClientOnLobbyPlayersUpdated;
            _gameClient.ChatServerMessage += GameClientOnChatServerMessage;
            _gameClient.ChatPlayerMessage += GameClientOnChatPlayerMessage;
            _gameClient.GameStarting += starting => GameStarting?.Invoke(new RemoteGame(_gameClient, _myPlayerId));

            _gameClient.Join(playerName, ip, port);
        }

        public List<IMessage> GetStoredChatMessages()
        {
            return _gameClient.ChatMessages;
        }
        
        public void DisconnectPlayer()
        {
            _gameClient.DisconnectPlayer();
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
            _gameClient.LobbyPositionSwitchRequest(playerPosition);
        }

        public void ColorSwitchRequest()
        {
            _gameClient.LobbyColorSwitchRequest();
        }

        public void ChatSendMessageRequest(string message)
        {
            _gameClient.ChatSendMessageRequest(message);
        }
        
        private void GameClientOnLobbyException(LobbyActionException lobbyActionException)
        {
            LobbyException?.Invoke(lobbyActionException.Message);
        }

        private void GameClientOnSetMyPlayerId(SetPlayerId setPlayerId)
        {
            _myPlayerId = setPlayerId.PlayerId;
            SetMyPlayerId?.Invoke(_myPlayerId);
        }

        private void GameClientOnLobbyPlayersUpdated(LobbyPlayersUpdate lobbyPlayersUpdate)
        {
            var lobbyPlayers = new List<LobbyPlayer>();
            foreach (var lobbyPlayer in lobbyPlayersUpdate.LobbyPlayers)
            {
                lobbyPlayers.Add(new LobbyPlayer(lobbyPlayer.PlayerId, lobbyPlayer.PlayerName,
                    Color.FromArgb(lobbyPlayer.Color), (PlayerPosition)lobbyPlayer.PlayerPosition));
            }

            _lobbyPlayers = lobbyPlayers;
            LobbyPlayersUpdated?.Invoke(lobbyPlayers);
        }

        private void GameClientOnChatServerMessage(VsadilNestihlNetworking.Messages.Chat.ChatServerMessage chatServerMessage)
        {
            ChatServerMessage?.Invoke(chatServerMessage.Message);
        }

        private void GameClientOnChatPlayerMessage(VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessage chatPlayerMessage)
        {
            var lobbyPlayer = _lobbyPlayers.Find(x => x.PlayerId == chatPlayerMessage.PlayerId);
            if (lobbyPlayer == null)
                return;

            ChatPlayerMessage?.Invoke(lobbyPlayer, chatPlayerMessage.Message);
        }
    }
}
