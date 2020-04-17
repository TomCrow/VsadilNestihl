using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Player;
using VsadilNestihl.GUI.GameCanvas.Drawables;
using VsadilNestihl.GUI.GameCanvas.Helpers;

namespace VsadilNestihl.GUI.GameWindow
{
    public class GameWindowGui : IGameView
    {
        private readonly IGameWindowView _view;
        private Dictionary<int, PlayerDrawable> _playerDrawables = new Dictionary<int, PlayerDrawable>();

        public IGameData GameData { get; private set; }
        public IPlayerController PlayerController { get; private set; }

        public event Action Loaded;
        
        public GameWindowGui(IGameWindowView gameWindowView)
        {
            _view = gameWindowView;

            var boardDrawable = new BoardDrawable(new System.Drawing.Point(0, 0));
            _view.AddDrawable(boardDrawable);

            var diceDrawable = new DiceDrawable(new System.Drawing.Point(724 / 2, 724 / 2));
            _view.AddDrawable(diceDrawable);

            var boardPositionsDrawables = CommonDrawables.GetBoardPositions(BoardPositionClicked);
            _view.AddDrawables(boardPositionsDrawables);
        }

        public void SetGameData(IGameData gameData)
        {
            GameData = gameData;
        }

        public void SetPlayerController(IPlayerController playerController)
        {
            PlayerController = playerController;
        }

        public void GameWindowLoaded()
        {
            Loaded?.Invoke();
        }

        public void ReloadAllPlayers()
        {
            _playerDrawables.Clear();

            var placesPlayerDrawables = new Dictionary<ConcretePlace, List<PlayerDrawable>>();
            foreach (var playerDataKeyVal in GameData.GetPlayers())
            {
                var playerId = playerDataKeyVal.Key;
                var playerData = playerDataKeyVal.Value;
                var playerDrawable = new PlayerDrawable(playerData.Color);
                _playerDrawables.Add(playerId, playerDrawable);

                var concretePlace = (ConcretePlace)playerData.Place.GetPlaceId();
                if (!placesPlayerDrawables.ContainsKey(concretePlace))
                    placesPlayerDrawables.Add(concretePlace, new List<PlayerDrawable>());

                placesPlayerDrawables[concretePlace].Add(playerDrawable);
            }

            foreach (var placePlayerDrawables in placesPlayerDrawables)
            {
                var leftCornerPoint = PlacesPositions.GetByPlaceAndPosition(placePlayerDrawables.Key, 0);
                PlayerPositionSetterHelper.SetPlayersPositions(placePlayerDrawables.Value, leftCornerPoint);
            }

            _view.AddDrawables(_playerDrawables.Values);
        }

        private void BoardPositionClicked(ConcretePlace concretePlace, int positionId)
        {
            Console.WriteLine($"Place clicked: {concretePlace} position: {positionId}");
        }

        /*private readonly IGameWindowView _view;
        private readonly Game.IGameData _gameData;
        private readonly Game.GameManager _gameManager;

        

        public GameWindowGui(IGameWindowView gameWindowView)
        {
            _view = gameWindowView;

            var board = new BoardFactory().CreateBoard();
            var gameSettings = new Game.GameSettings();
            var lobbyPlayers = new List<Game.Lobby.LobbyPlayer>
            {
                new Game.Lobby.LobbyPlayer(1, "Hráč 1", System.Drawing.Color.Blue, Game.Lobby.PlayerPosition.Position1),
                new Game.Lobby.LobbyPlayer(2, "Hráč 2", System.Drawing.Color.Coral, Game.Lobby.PlayerPosition.Position2),
                new Game.Lobby.LobbyPlayer(3, "Hráč 3", System.Drawing.Color.Green, Game.Lobby.PlayerPosition.Position3),
                new Game.Lobby.LobbyPlayer(4, "Hráč 4", System.Drawing.Color.Red, Game.Lobby.PlayerPosition.Position4),
                new Game.Lobby.LobbyPlayer(5, "Hráč 5", System.Drawing.Color.Purple, Game.Lobby.PlayerPosition.Position5),
                new Game.Lobby.LobbyPlayer(6, "Hráč 6", System.Drawing.Color.Yellow, Game.Lobby.PlayerPosition.Position6),
            };

            var boardDrawable = new BoardDrawable(new System.Drawing.Point(0, 0));
            _view.AddDrawable(boardDrawable);

            var diceDrawable = new DiceDrawable(new System.Drawing.Point(724 / 2, 724 / 2));
            _view.AddDrawable(diceDrawable);

            var boardPositionsDrawables = CommonDrawables.GetBoardPositions(BoardPositionClicked);
            _view.AddDrawables(boardPositionsDrawables);

            _gameManager = new Game.GameManager(board, gameSettings, this, lobbyPlayers);
            _gameManager.Start();
        }

        public void GameStarted(List<Game.Player.Player> players)
        {
            base.GameStarted(players);

            var placesPlayerDrawables = new Dictionary<ConcretePlace, List<PlayerDrawable>>();
            foreach (var playerDataKeyVal in Players)
            {
                var playerId = playerDataKeyVal.Key;
                var playerData = playerDataKeyVal.Value;
                var playerDrawable = new PlayerDrawable(playerData.Color);
                _playerDrawables.Add(playerId, playerDrawable);

                var concretePlace = (ConcretePlace) playerData.Place.GetPlaceId();
                if (!placesPlayerDrawables.ContainsKey(concretePlace))
                    placesPlayerDrawables.Add(concretePlace, new List<PlayerDrawable>());

                placesPlayerDrawables[concretePlace].Add(playerDrawable);
            }

            foreach (var placePlayerDrawables in placesPlayerDrawables)
            {
                var leftCornerPoint = PlacesPositions.GetByPlaceAndPosition(placePlayerDrawables.Key, 0);
                PlayerPositionSetterHelper.SetPlayersPositions(placePlayerDrawables.Value, leftCornerPoint);
            }

            _view.AddDrawables(_playerDrawables.Values);
        }

        */
    }
}
