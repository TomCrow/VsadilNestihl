using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;
using VsadilNestihl.Networking;
using VsadilNestihl.Networking.Messages;
using VsadilNestihl.Networking.Messages.Lobby;

namespace VsadilNestihl.Game.Lobby
{
    public class PlayerHandler
    {
        private readonly NetworkLobby _networkLobby;
        private bool _joined;

        public Receiver Receiver { get; private set; }
        public LobbyPlayer LobbyPlayer { get; private set; }

        public PlayerHandler(NetworkLobby networkLobby, Receiver receiver)
        {
            _networkLobby = networkLobby;
            Receiver = receiver;

            receiver.SubscribeForMessage<PlayerJoinRequest>(OnPlayerJoinRequest);
            receiver.SubscribeForMessage<PlayerPositionSwitchRequest>(OnPlayerPositionSwitchRequest);
            receiver.SubscribeForMessage<PlayerColorSwitchRequest>(OnPlayerColorSwitchRequest);
            receiver.SubscribeForMessage<Networking.Messages.Chat.ChatPlayerMessageRequest>(OnChatPlayerMessageRequest);

            var joinTimer = new Timer {AutoReset = false, Interval = 7000};
            joinTimer.Elapsed += JoinTimerOnElapsed;
        }
        
        public void SetLobbyPlayer(LobbyPlayer lobbyPlayer)
        {
            LobbyPlayer = lobbyPlayer;
            Receiver.SendMessage(new SetPlayerId(lobbyPlayer.PlayerId));
        }

        public void LobbyPlayersUpdate(LobbyPlayersUpdate lobbyPlayersUpdate)
        {
            Receiver.SendMessage(lobbyPlayersUpdate);
        }

        public void ChatServerMessage(string message)
        {
            Receiver.SendMessage(new VsadilNestihl.Networking.Messages.Chat.ChatServerMessage(message));
        }

        public void ChatPlayerMessage(VsadilNestihl.Networking.Messages.Chat.ChatPlayerMessage chatPlayerMessage)
        {
            Receiver.SendMessage(chatPlayerMessage);
        }

        public void GameStarting()
        {
            Receiver.SendMessage(new GameStarting());
        }

        public InnerRemotePlayerController CreateInnerRemotePlayerController(VsadilNestihl.Game.Player.Player player)
        {
            Receiver.UnsubscribeFromMessage<PlayerJoinRequest>(OnPlayerJoinRequest);
            Receiver.UnsubscribeFromMessage<PlayerPositionSwitchRequest>(OnPlayerPositionSwitchRequest);
            Receiver.UnsubscribeFromMessage<PlayerColorSwitchRequest>(OnPlayerColorSwitchRequest);
            Receiver.UnsubscribeFromMessage<Networking.Messages.Chat.ChatPlayerMessageRequest>(OnChatPlayerMessageRequest);

            return new InnerRemotePlayerController(Receiver, player);
        }

        private void OnPlayerJoinRequest(PlayerJoinRequest playerJoinRequest, Receiver receiver)
        {
            Receiver.UnsubscribeFromMessage<PlayerJoinRequest>(OnPlayerJoinRequest);

            if (_joined)
                return;

            try
            {
                _networkLobby.PlayerJoinRequest(this, playerJoinRequest.PlayerName);
                _joined = true;
            }
            catch (InvalidActionException exception)
            {
                Receiver.SendMessage(new LobbyActionException(exception.Message));
                Receiver.SendMessage(new Disconnect());
                //_receiver.Disconnect();
            }
        }
        
        private void JoinTimerOnElapsed(object sender, ElapsedEventArgs e)
        {
            if (!_joined)
            {
                Receiver.SendMessage(new LobbyActionException("Player join request timeout."));
                Receiver.SendMessage(new Disconnect());
                //_receiver.Disconnect();
            }

            if (sender is IDisposable disposable)
                disposable.Dispose();
        }

        private void OnPlayerPositionSwitchRequest(PlayerPositionSwitchRequest playerPositionSwitchRequest, Receiver receiver)
        {
            if (!_joined)
                return;

            _networkLobby.PlayerPositionSwitchRequest(this, (PlayerPosition)playerPositionSwitchRequest.PlayerPosition);
        }

        private void OnPlayerColorSwitchRequest(PlayerColorSwitchRequest playerColorSwitchRequest, Receiver receiver)
        {
            if (!_joined)
                return;

            _networkLobby.PlayerColorSwitchRequest(this);
        }

        private void OnChatPlayerMessageRequest(Networking.Messages.Chat.ChatPlayerMessageRequest chatPlayerMessageRequest, Receiver receiver)
        {
            if (!_joined)
                return;

            _networkLobby.PlayerChatSendMessageRequest(this, chatPlayerMessageRequest.Message);
        }
    }
}
