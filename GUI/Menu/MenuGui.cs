using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game;
using VsadilNestihl.GUI.GameWindow;

namespace VsadilNestihl.GUI.Menu
{
    public class MenuGui
    {
        private readonly IMenuView _view;

        public MenuGui(IMenuView view)
        {
            _view = view;
        }

        public void SoloGameClick()
        {
            if (string.IsNullOrWhiteSpace(_view.GetPlayerName()))
            {
                _view.ShowNameRequired();
                return;
            }

            var gameWindowView = new GameWindow.FormGameWindow();
            gameWindowView.ShowDialog();
        }

        public void HostGameClick()
        {
            if (string.IsNullOrWhiteSpace(_view.GetPlayerName()))
            {
                _view.ShowNameRequired();
                return;
            }

            NetworkLobby.FormNetworkLobby networkLobbyView = null;
            try
            {
                var networkLobby = new Game.Lobby.NetworkLobby();

                networkLobbyView = new NetworkLobby.FormNetworkLobby();
                var networkLobbyGui = networkLobbyView.GetNetworkLobbyGui();
                networkLobbyGui.SetNetworkLobby(networkLobby);

                networkLobby.StartLobby(_view.GetPlayerName(), _view.GetHostPort());
            }
            catch (Exception exception)
            {
                _view.ShowException(exception);
            }

            if (networkLobbyView != null)
            {
                networkLobbyView.ShowDialog();
                var networkLobbyGui = networkLobbyView.GetNetworkLobbyGui();
                if (networkLobbyGui.OpenGameWindow && networkLobbyGui.LocalGame != null)
                    OpenLocalGame(networkLobbyGui.LocalGame);
            }
        }

        public void JoinGameClick()
        {
            if (string.IsNullOrWhiteSpace(_view.GetPlayerName()))
            {
                _view.ShowNameRequired();
                return;
            }

            var result = 0; // 0 = no result yet, 1 = success, 2 = fail
            var joiningPlayer = new Game.Lobby.JoiningPlayer();
            var joiningPlayerDelegates = new Helpers.JoiningPlayerDelegates(joiningPlayer);
            joiningPlayerDelegates.SetMyPlayerId += i => result = 1;
            joiningPlayerDelegates.LobbyException += s => _view.ShowException(new Exception(s));
            joiningPlayerDelegates.Disconnected += () => result = 2;

            _view.SetLoading(true);
            try
            {
                joiningPlayer.Join(_view.GetPlayerName(), _view.GetJoinIp(), _view.GetJoinPort());
            }
            catch (Exception exception)
            {
                result = 2;
                _view.ShowException(exception);
            }

            // Počkat na výsledek
            while (result == 0)
                System.Threading.Thread.Sleep(200);

            _view.SetLoading(false);
            joiningPlayerDelegates.Unsubsribe();

            if (result == 1)
            {
                var networkLobbyView = new NetworkLobby.FormNetworkLobby();
                var networkLobbyGui = networkLobbyView.GetNetworkLobbyGui();
                networkLobbyGui.SetJoiningPlayer(joiningPlayer);
                networkLobbyView.ShowDialog();

                if (networkLobbyGui.OpenGameWindow && networkLobbyGui.RemoteGame != null)
                    OpenRemoteGame(networkLobbyGui.RemoteGame);
            }
        }

        private void OpenLocalGame(LocalGame localGame)
        {
            var formGameWindow = new FormGameWindow();
            var gameWindowGui = formGameWindow.GetGameWindowGui();
            gameWindowGui.SetGameData(localGame);
            localGame.SetGameView(gameWindowGui);

            formGameWindow.ShowDialog();
        }

        private void OpenRemoteGame(RemoteGame remoteGame)
        {
            var formGameWindow = new FormGameWindow();
            var gameWindowGui = formGameWindow.GetGameWindowGui();
            gameWindowGui.SetGameData(remoteGame);
            remoteGame.SetGameView(gameWindowGui);

            formGameWindow.ShowDialog();
        }
    }
}
