using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.Menu.Helpers
{
    public class JoiningPlayerDelegates
    {
        private readonly Game.Lobby.JoiningPlayer _joiningPlayer;

        public Action<int> SetMyPlayerId;
        public Action<string> LobbyException;
        public Action Disconnected;

        public JoiningPlayerDelegates(Game.Lobby.JoiningPlayer joiningPlayer)
        {
            _joiningPlayer = joiningPlayer;

            _joiningPlayer.SetMyPlayerId += OnSetMyPlayerId;
            _joiningPlayer.LobbyException += OnLobbyException;
            _joiningPlayer.Disconnected += OnDisconnected;
        }

        public void Unsubsribe()
        {
            _joiningPlayer.SetMyPlayerId -= OnSetMyPlayerId;
            _joiningPlayer.LobbyException -= OnLobbyException;
            _joiningPlayer.Disconnected -= OnDisconnected;

            SetMyPlayerId = null;
            LobbyException = null;
            Disconnected = null;
        }

        private void OnSetMyPlayerId(int myPlayerId)
        {
            SetMyPlayerId?.Invoke(myPlayerId);
        }

        private void OnLobbyException(string message)
        {
            LobbyException?.Invoke(message);
        }

        private void OnDisconnected()
        {
            Disconnected?.Invoke();
        }
    }
}
