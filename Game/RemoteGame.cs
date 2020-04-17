using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Player;
using VsadilNestihlNetworking.Messages.Game;

namespace VsadilNestihl.Game
{
    public class RemoteGame : IGameData
    {
        private readonly Network.GameClient _gameClient;
        private readonly int _myPlayerId;
        private IGameView _gameView;
        private bool _gameViewLoaded = false;

        private readonly Dictionary<int, IPlayerData> _players = new Dictionary<int, IPlayerData>();
        private int _currentPlayerId;
        private bool _currentPlayerRolledThisTurn;

        public RemoteGame(Network.GameClient gameClient , int myPlayerId)
        {
            _gameClient = gameClient;
            _myPlayerId = myPlayerId;

            _gameClient.GameStarted += GameClientOnGameStarted;
            _gameClient.PlayerSetMoney += GameClientOnPlayerSetMoney;
            _gameClient.PlayerRolledDice += GameClientOnPlayerRolledDice;
            _gameClient.PlayerRolledThisTurn += GameClientOnPlayerRolledThisTurn;
            _gameClient.PlayerSetPlace += GameClientOnPlayerSetPlace;
            _gameClient.NextRound += GameClientOnNextRound;
        }

        public void SetGameView(IGameView gameView)
        {
            _gameView = gameView;
            _gameView.Loaded += GameViewOnLoaded;
        }

        private void GameViewOnLoaded()
        {
            _gameViewLoaded = true;
            if (_players.Any())
                _gameView.ReloadAllPlayers();
        }

        public Dictionary<int, IPlayerData> GetPlayers()
        {
            return _players;
        }

        public int GetCurrentPlayerId()
        {
            return _currentPlayerId;
        }

        public bool GetCurrentPlayerRolledThisTurn()
        {
            return _currentPlayerRolledThisTurn;
        }

        private void GameClientOnGameStarted(GameStarted gameStarted)
        {
            foreach (var player in gameStarted.Players)
            {
                var playerData = new PlayerData(player.PlayerId,
                    player.Name,
                    Color.FromArgb(player.Color),
                    (PlayerPosition) player.PlayerPosition)
                {
                    Place = new Place((ConcretePlace)player.PlaceId, ""),
                    Money = player.Money
                };

                _players.Add(playerData.PlayerId, playerData);
            }

            if (_gameViewLoaded)
                _gameView.ReloadAllPlayers();
        }

        private void GameClientOnPlayerSetMoney(PlayerSetMoney playerSetMoney)
        {
            _players[playerSetMoney.PlayerId].Money = playerSetMoney.Money;
        }

        private void GameClientOnPlayerRolledDice(PlayerRolledDice playerRolledDice)
        {
            // TODO:
        }

        private void GameClientOnPlayerRolledThisTurn(PlayerRolledThisTurn playerRolledThisTurn)
        {
            if (playerRolledThisTurn.PlayerId == _currentPlayerId)
                _currentPlayerRolledThisTurn = playerRolledThisTurn.RolledThisTurn;
        }
        private void GameClientOnPlayerSetPlace(PlayerSetPlace playerSetPlace)
        {
            _players[playerSetPlace.PlayerId].Place = new Place((ConcretePlace)playerSetPlace.PlaceId, "");
        }

        private void GameClientOnNextRound(NextRound nextRound)
        {
            _currentPlayerId = nextRound.PlayerId;
        }
    }
}
