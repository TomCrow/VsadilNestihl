using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Exceptions;
using VsadilNestihl.Game.Logic;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;
using VsadilNestihl.Networking;
using VsadilNestihl.Networking.Messages.Lobby;
using VsadilNestihl.Networking.SerializationEngines;

namespace VsadilNestihl.Game.Lobby
{
    public class NetworkLobby
    {
        private Server _server;
        private LobbyPlayer _hostPlayer;
        private readonly List<PlayerHandler> _playerHandlers = new List<PlayerHandler>();
        private int _nextPlayerId = 2;

        public event Action<int> SetMyPlayerId;
        public event Action<List<LobbyPlayer>> LobbyPlayersUpdated;
        public event Action<string> ChatServerMessage;
        public event Action<LobbyPlayer, string> ChatPlayerMessage;
        public event Action<LocalGame> GameStarting;

        public NetworkLobby() { }

        public void StartLobby(string playerName, int port)
        {
            if (_server != null)
                return;

            _server = new Server(port, new IdJsonSerialization());
            _server.OnClientConnected += ServerOnOnClientConnected;
            _server.OnClientDisonnected += ServerOnOnClientDisonnected;
            _server.Start();

            _hostPlayer = new LobbyPlayer(1, playerName, Color.Blue, PlayerPosition.Position1);
            SetMyPlayerId?.Invoke(1);
            LobbyPlayersUpdate();

            ServerChatSendMessage($"Initialization založeno hráčem {playerName} a naslouchá na portu: {port}");
        }

        public void StopServer()
        {
            _server?.Stop();
        }

        public void PlayerJoinRequest(PlayerHandler playerHandler, string playerName)
        {
            if (GetAllLobbyPlayers().Any(x => x.PlayerName == playerName))
                throw new InvalidActionException("This player name is already taken.");

            var freePosition = GetNextFreePosition();
            var freeColor = freePosition != PlayerPosition.Spectator ? GetNextFreeColor(null) : Color.Black;
            var lobbyPlayer = new LobbyPlayer(_nextPlayerId, playerName, freeColor, freePosition)
            {
                PlayerHandler = playerHandler
            };
            _nextPlayerId++;

            playerHandler.SetLobbyPlayer(lobbyPlayer);
            _playerHandlers.Add(playerHandler);

            LobbyPlayersUpdate();

            ServerChatSendMessage($"Připojil se hráč {playerName}");
        }

        public void HostPositionSwitchRequest(PlayerPosition playerPosition)
        {
            if (playerPosition == PlayerPosition.Spectator)
            {
                _hostPlayer.PlayerPosition = playerPosition;
                LobbyPlayersUpdate();
            }
            else
            {
                if (GetAllLobbyPlayers().Find(x => x.PlayerPosition == playerPosition) != null)
                    return;

                // Když byl doteď divák, nastavit volnou barvu
                if (_hostPlayer.PlayerPosition == PlayerPosition.Spectator)
                    _hostPlayer.Color = GetNextFreeColor(null);

                _hostPlayer.PlayerPosition = playerPosition;
                LobbyPlayersUpdate();
            }
        }
        
        public void PlayerPositionSwitchRequest(PlayerHandler playerHandler, PlayerPosition playerPosition)
        {
            if (!_playerHandlers.Contains(playerHandler))
                return;

            if (playerPosition == PlayerPosition.Spectator)
            {
                playerHandler.LobbyPlayer.PlayerPosition = playerPosition;
                LobbyPlayersUpdate();
            }
            else
            {
                if (GetAllLobbyPlayers().Find(x => x.PlayerPosition == playerPosition) != null)
                    return;

                // Když byl doteď divák, nastavit volnou barvu
                if (playerHandler.LobbyPlayer.PlayerPosition == PlayerPosition.Spectator)
                    playerHandler.LobbyPlayer.Color = GetNextFreeColor(null);

                playerHandler.LobbyPlayer.PlayerPosition = playerPosition;
                LobbyPlayersUpdate();
            }
        }

        public void HostColorSwitchRequest()
        {
            _hostPlayer.Color = GetNextFreeColor(_hostPlayer.Color);
            LobbyPlayersUpdate();
        }

        public void PlayerColorSwitchRequest(PlayerHandler playerHandler)
        {
            if (!_playerHandlers.Contains(playerHandler))
                return;

            if (playerHandler.LobbyPlayer.PlayerPosition == PlayerPosition.Spectator)
                return;

            playerHandler.LobbyPlayer.Color = GetNextFreeColor(playerHandler.LobbyPlayer.Color);
            LobbyPlayersUpdate();
        }

        public void HostChatSendMessageRequest(string message)
        {
            ChatSendMessage(_hostPlayer, message);
        }

        public void PlayerChatSendMessageRequest(PlayerHandler playerHandler, string message)
        {
            if (!_playerHandlers.Contains(playerHandler))
                return;

            ChatSendMessage(playerHandler.LobbyPlayer, message);
        }

        public void StartGame()
        {
            var playingPlayers = GetAllLobbyPlayers().Where(x => x.PlayerPosition != PlayerPosition.Spectator).ToList();
            if (playingPlayers.Count < 2)
                throw new InvalidActionException("Not enough players.");

            _server.OnClientConnected -= ServerOnOnClientConnected;
            _server.OnClientDisonnected -= ServerOnOnClientDisonnected; // TODO: postarat se o tyto handlery

            foreach (var lobbyPlayer in GetAllLobbyPlayers().Where(x => x.PlayerHandler != null))
                lobbyPlayer.PlayerHandler.GameStarting();

            // Game updaters
            var gameUpdaters = new List<IGameUpdater>();
            var localGame = new LocalGame(_hostPlayer.PlayerId);
            gameUpdaters.Add(localGame);
            foreach (var lobbyPlayer in GetAllLobbyPlayers().Where(x => x.PlayerHandler != null))
                gameUpdaters.Add(new RemoteGameUpdater(lobbyPlayer.PlayerHandler.Receiver));

            var board = new BoardFactory().CreateBoard();
            var gameSettings = new GameSettings();

            // Build the game manager
            var gameManager = new GameManager(board, gameSettings, new MultipleGameUpdater(gameUpdaters), GetAllLobbyPlayers());
            gameManager.DiceRolling = new DiceRolling(gameManager);
            gameManager.TurnLogic = new TurnLogic(gameManager);
            gameManager.Start();

            var hostPlayer = gameManager.Players.Find(x => x.PlayerId == _hostPlayer.PlayerId);
            if (hostPlayer == null)
                throw new FatalGameException("Invalid host player id");

            var hostPlayerController = new LocalPlayerController(hostPlayer);
            localGame.SetPlayerController(hostPlayerController);

            GameStarting?.Invoke(localGame);
        }

        private void ServerChatSendMessage(string message)
        {
            ChatServerMessage?.Invoke(message);

            foreach (var lobbyPlayer in GetAllLobbyPlayers().Where(x => x.PlayerHandler != null))
                lobbyPlayer.PlayerHandler.ChatServerMessage(message);
        }

        private void ChatSendMessage(LobbyPlayer player, string message)
        {
            if (message.Length > 1000)
                return;

            ChatPlayerMessage?.Invoke(player, message);

            var chatPlayerMessage = new VsadilNestihl.Networking.Messages.Chat.ChatPlayerMessage(player.PlayerId, message);
            foreach (var lobbyPlayer in GetAllLobbyPlayers().Where(x => x.PlayerHandler != null))
                lobbyPlayer.PlayerHandler.ChatPlayerMessage(chatPlayerMessage);
        }

        private List<LobbyPlayer> GetAllLobbyPlayers()
        {
            var lobbyPlayers = new List<LobbyPlayer>();
            lobbyPlayers.Add(_hostPlayer);
            foreach (var playerHandler in _playerHandlers)
                lobbyPlayers.Add(playerHandler.LobbyPlayer);

            return lobbyPlayers;
        }

        private void ServerOnOnClientConnected(object sender, Receiver receiver)
        {
            var playerHandler = new PlayerHandler(this, receiver);
        }

        private void ServerOnOnClientDisonnected(object sender, Receiver receiver)
        {
            var playerHandler = _playerHandlers.Find(x => x.Receiver == receiver);
            if (playerHandler == null)
                return;

            _playerHandlers.Remove(playerHandler);
            LobbyPlayersUpdate();

            ServerChatSendMessage($"{playerHandler.LobbyPlayer.PlayerName} se odpojil.");
        }

        private Color GetNextFreeColor(Color? currentColor)
        {
            var availableColors = new List<Color>
            {
                Color.Blue, Color.Red, Color.Green, Color.HotPink, Color.Cyan, Color.Gold, Color.Coral
            };

            var currentIndex = -1;
            if (currentColor.HasValue &&
                availableColors.Contains(currentColor.Value))
                currentIndex = availableColors.IndexOf(currentColor.Value);

            for (var i = 0; i < availableColors.Count; i++)
            {
                currentIndex++;
                if (currentIndex >= availableColors.Count)
                    currentIndex = 0;

                if (GetAllLobbyPlayers().Where(x => x.PlayerPosition != PlayerPosition.Spectator).Any(x => x.Color == availableColors[currentIndex]))
                    continue;

                return availableColors[currentIndex];
            }

            throw new FatalGameException("No free colors left.");
        }

        private PlayerPosition GetNextFreePosition()
        {
            var allLobbyPlayers = GetAllLobbyPlayers();

            if (allLobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position1) == null)
                return PlayerPosition.Position1;

            if (allLobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position2) == null)
                return PlayerPosition.Position2;

            if (allLobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position3) == null)
                return PlayerPosition.Position3;

            if (allLobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position4) == null)
                return PlayerPosition.Position4;

            if (allLobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position5) == null)
                return PlayerPosition.Position5;

            if (allLobbyPlayers.Find(x => x.PlayerPosition == PlayerPosition.Position6) == null)
                return PlayerPosition.Position6;

            return PlayerPosition.Spectator;
        }

        private void LobbyPlayersUpdate()
        {
            var allLobbyPlayers = GetAllLobbyPlayers();

            var lobbyPlayersUpdate = new LobbyPlayersUpdate(new List<VsadilNestihl.Networking.Messages.Lobby.LobbyPlayer>());
            foreach (var lobbyPlayer in allLobbyPlayers)
            {
                lobbyPlayersUpdate.LobbyPlayers.Add(new VsadilNestihl.Networking.Messages.Lobby.LobbyPlayer(
                    lobbyPlayer.PlayerId, lobbyPlayer.PlayerName, lobbyPlayer.Color.ToArgb(), (int) lobbyPlayer.PlayerPosition));
            }

            LobbyPlayersUpdated?.Invoke(allLobbyPlayers);

            foreach (var lobbyPlayer in allLobbyPlayers.Where(x => x.PlayerHandler != null))
                lobbyPlayer.PlayerHandler.LobbyPlayersUpdate(lobbyPlayersUpdate);
        }
    }
}
