using System;
using System.Collections.Generic;
using System.Deployment.Application;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihl.Game.Player;

namespace VsadilNestihl.GUI.NetworkLobby
{
    public class NetworkLobbyGui
    {
        private readonly INetworkLobbyView _view;
        private Game.Lobby.NetworkLobby _networkLobby;
        private Game.Lobby.JoiningPlayer _joiningPlayer;
        private bool _lobbyIsClosed = false;

        public bool OpenGameWindow { get; private set; }
        public LocalGame LocalGame { get; private set; }
        public RemoteGame RemoteGame { get; private set; }

        public NetworkLobbyGui(INetworkLobbyView view)
        {
            _view = view;
        }

        public void SetNetworkLobby(Game.Lobby.NetworkLobby networkLobby)
        {
            _networkLobby = networkLobby;
            _networkLobby.SetMyPlayerId += OnSetMyPlayerId;
            _networkLobby.LobbyPlayersUpdated += OnLobbyPlayersUpdated;
            _networkLobby.ChatServerMessage += OnChatServerMessage;
            _networkLobby.ChatPlayerMessage += OnChatPlayerMessage;
            _networkLobby.GameStarting += OnHostGameStarting;

            _view.EnableHostFunctions();
        }

        public void SetJoiningPlayer(Game.Lobby.JoiningPlayer joiningPlayer)
        {
            _joiningPlayer = joiningPlayer;
            _joiningPlayer.Disconnected += () =>
            {
                if (_lobbyIsClosed) return;
                _view.ShowLobbyException("Odpojeno ze serveru.");
                _view.CloseLobby();
            };
            _joiningPlayer.LobbyException += message => _view.ShowLobbyException(message);
            _joiningPlayer.SetMyPlayerId += OnSetMyPlayerId;
            _joiningPlayer.LobbyPlayersUpdated += OnLobbyPlayersUpdated;
            _joiningPlayer.ChatServerMessage += OnChatServerMessage;
            _joiningPlayer.ChatPlayerMessage += OnChatPlayerMessage;
            _joiningPlayer.GameStarting += OnRemoteGameStarting;
            
            OnSetMyPlayerId(_joiningPlayer.GetMyPlayerId());

            var lobbyPlayers = _joiningPlayer.GetLobbyPlayers();
            OnLobbyPlayersUpdated(lobbyPlayers);
            
            foreach (var chatMessage in _joiningPlayer.GetStoredChatMessages())
            {
                if (chatMessage is VsadilNestihl.Networking.Messages.Chat.ChatServerMessage chatServerMessage)
                    OnChatServerMessage(chatServerMessage.Message);

                if (chatMessage is VsadilNestihl.Networking.Messages.Chat.ChatPlayerMessage chatPlayerMessage)
                {
                    var lobbyPlayer = lobbyPlayers.Find(x => x.PlayerId == chatPlayerMessage.PlayerId);
                    if (lobbyPlayer == null)
                        continue;

                    OnChatPlayerMessage(lobbyPlayer, chatPlayerMessage.Message);
                }
            }
        }

        public void LobbyClosed()
        {
            if (OpenGameWindow == false)
            {
                if (_networkLobby != null)
                {
                    _networkLobby.StopServer();
                }
                else if (_joiningPlayer != null)
                {
                    _joiningPlayer.DisconnectPlayer();
                }
            }

            _lobbyIsClosed = true;
        }

        public void EmptyPositionClick(PlayerPosition playerPosition)
        {
            if (_networkLobby != null)
            {
                _networkLobby.HostPositionSwitchRequest(playerPosition);
            }
            else if (_joiningPlayer != null)
            {
                _joiningPlayer.PositionSwitchRequest(playerPosition);
            }
        }

        public void JoinSpectatorsClick()
        {
            if (_networkLobby != null)
            {
                _networkLobby.HostPositionSwitchRequest(PlayerPosition.Spectator);
            }
            else if (_joiningPlayer != null)
            {
                _joiningPlayer.PositionSwitchRequest(PlayerPosition.Spectator);
            }
        }

        public void ColorSwitchClick()
        {
            if (_networkLobby != null)
            {
                _networkLobby.HostColorSwitchRequest();
            }
            else if (_joiningPlayer != null)
            {
                _joiningPlayer.ColorSwitchRequest();
            }
        }

        public void ChatSendMessageClick(string message)
        {
            if (_networkLobby != null)
            {
                _networkLobby.HostChatSendMessageRequest(message);
            }
            else if (_joiningPlayer != null)
            {
                _joiningPlayer.ChatSendMessageRequest(message);
            }
        }

        public void StartClick()
        {
            if (_networkLobby == null)
                return;

            try
            {
                _networkLobby.StartGame();
            }
            catch (InvalidActionException invalidActionException)
            {
                _view.ShowLobbyException(invalidActionException.Message);
            }
        }

        private void OnSetMyPlayerId(int myPlayerId)
        {
            _view.SetMyPlayerId(myPlayerId);
        }

        private void OnLobbyPlayersUpdated(List<Game.Lobby.LobbyPlayer> lobbyPlayers)
        {
            _view.UpdateLobbyPlayers(lobbyPlayers);
        }

        private void OnChatServerMessage(string message)
        {
            _view.AddChatMessage($"SERVER: {message}");
        }

        private void OnChatPlayerMessage(Game.Lobby.LobbyPlayer lobbyPlayer, string message)
        {
            _view.AddChatMessage($"{lobbyPlayer.PlayerName}: {message}");
        }

        private void OnHostGameStarting(LocalGame localGame)
        {
            LocalGame = localGame;
            OpenGameWindow = true;
            _view.CloseLobby();
        }

        private void OnRemoteGameStarting(RemoteGame remoteGame)
        {
            RemoteGame = remoteGame;
            OpenGameWindow = true;
            _view.CloseLobby();
        }
    }
}
