using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VsadilNestihl.GUI.GameWindow
{
    public class GameWindowGui : Game.LocalGameUpdater
    {
        private readonly IGameWindowView _view;
        private readonly Game.GameManager _gameManager;

        private Dictionary<int, GameCanvas.Drawables.PlayerDrawable> _playerDrawables = new Dictionary<int, GameCanvas.Drawables.PlayerDrawable>();

        public GameWindowGui(IGameWindowView gameWindowView)
        {
            _view = gameWindowView;

            var board = new Game.Board.DostihyASazky.BoardFactory().CreateBoard();
            var gameSettings = new Game.GameSettings();
            var lobbyPlayers = new List<Game.Lobby.LobbyPlayer>
            {
                new Game.Lobby.LobbyPlayer(1, "Hráč 1", System.Drawing.Color.Blue, Game.Lobby.PlayerPosition.Position1),
                new Game.Lobby.LobbyPlayer(2, "Hráč 2", System.Drawing.Color.Coral, Game.Lobby.PlayerPosition.Position2),
            };

            _gameManager = new Game.GameManager(board, gameSettings, this, lobbyPlayers);
            _gameManager.Start();
        }

        public override void GameStarted(List<Game.Player.Player> players)
        {
            base.GameStarted(players);
            
            foreach (var playerDataKeyVal in Players)
            {
                var playerId = playerDataKeyVal.Key;
                var playerData = playerDataKeyVal.Value;
                var playerDrawable = new GameCanvas.Drawables.PlayerDrawable(playerData.Color);
                var playerPositionPoint = GameCanvas.PlacesPositions.GetByPlaceAndPosition((Game.Board.DostihyASazky.ConcretePlace)playerData.Place.GetPlaceId(), playerData.Position.GetPositionId());
                playerDrawable.SetPosition(playerPositionPoint.X + 25, playerPositionPoint.Y + 25);

                _playerDrawables.Add(playerId, playerDrawable);
                _view.AddDrawableToBoard(playerDrawable);
            }
        }
    }
}
