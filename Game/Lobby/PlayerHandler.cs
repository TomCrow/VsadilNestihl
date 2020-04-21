using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;
using VsadilNestihlNetworking;
using VsadilNestihlNetworking.Messages;
using VsadilNestihlNetworking.Messages.Lobby;

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

            receiver.MessageDispatcher.Add(typeof(PlayerJoinRequest), OnPlayerJoinRequest);
            receiver.MessageDispatcher.Add(typeof(PlayerPositionSwitchRequest), OnPlayerPositionSwitchRequest);
            receiver.MessageDispatcher.Add(typeof(PlayerColorSwitchRequest), OnPlayerColorSwitchRequest);
            receiver.MessageDispatcher.Add(typeof(VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessageRequest), OnChatPlayerMessageRequest);

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
            Receiver.SendMessage(new VsadilNestihlNetworking.Messages.Chat.ChatServerMessage(message));
        }

        public void ChatPlayerMessage(VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessage chatPlayerMessage)
        {
            Receiver.SendMessage(chatPlayerMessage);
        }

        public void GameStarting()
        {
            Receiver.SendMessage(new GameStarting());
        }

        public InnerRemotePlayerController CreateInnerRemotePlayerController(VsadilNestihl.Game.Player.Player player)
        {
            Receiver.MessageDispatcher.Remove(typeof(PlayerJoinRequest));
            Receiver.MessageDispatcher.Remove(typeof(PlayerPositionSwitchRequest));
            Receiver.MessageDispatcher.Remove(typeof(PlayerColorSwitchRequest));
            Receiver.MessageDispatcher.Remove(typeof(VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessageRequest));

            return new InnerRemotePlayerController(Receiver, player);
        }

        private void OnPlayerJoinRequest(IMessage message, Receiver receiver)
        {
            if (!(message is PlayerJoinRequest playerJoinRequest))
                return;

            Receiver.MessageDispatcher.Remove(typeof(PlayerJoinRequest));

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

        private void OnPlayerPositionSwitchRequest(IMessage message, Receiver receiver)
        {
            if (!(message is PlayerPositionSwitchRequest playerPositionSwitchRequest))
                return;

            if (!_joined)
                return;

            _networkLobby.PlayerPositionSwitchRequest(this, (PlayerPosition)playerPositionSwitchRequest.PlayerPosition);
        }

        private void OnPlayerColorSwitchRequest(IMessage message, Receiver receiver)
        {
            if (!(message is PlayerColorSwitchRequest))
                return;

            if (!_joined)
                return;

            _networkLobby.PlayerColorSwitchRequest(this);
        }

        private void OnChatPlayerMessageRequest(IMessage message, Receiver receiver)
        {
            if (!(message is VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessageRequest chatPlayerMessageRequest))
                return;

            if (!_joined)
                return;

            _networkLobby.PlayerChatSendMessageRequest(this, chatPlayerMessageRequest.Message);
        }
    }
}
