using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board.DostihyASazky;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;
using VsadilNestihlNetworking.Messages.Game;

namespace VsadilNestihl.Game
{
    public class RemoteGame : IGameData
    {
        private readonly Network.GameClient _gameClient;
        private readonly IPlayerController _playerController;
        private readonly int _myPlayerId;
        private IGameView _gameView;
        private bool _gameViewLoaded = false;

        private List<string> _preGameLoadServerMessages = new List<string>();

        private readonly Dictionary<int, IPlayerData> _players = new Dictionary<int, IPlayerData>();
        private int _currentPlayerId;
        private bool _currentPlayerRolledThisTurn;

        public RemoteGame(Network.GameClient gameClient , int myPlayerId)
        {
            _gameClient = gameClient;
            _myPlayerId = myPlayerId;
            _playerController = new RemotePlayerController(gameClient);
            _playerController.GameActionException += PlayerControllerOnGameActionException;

            _gameClient.StoreChatMessages = false;

            _gameClient.GameStarted += GameClientOnGameStarted;
            _gameClient.ChatServerMessage += GameClientOnChatServerMessage;
            _gameClient.ChatPlayerMessage += GameClientOnChatPlayerMessage;
            _gameClient.PlayerSetMoney += GameClientOnPlayerSetMoney;
            _gameClient.PlayerRolledDice += GameClientOnPlayerRolledDice;
            _gameClient.PlayerRolledThisTurn += GameClientOnPlayerRolledThisTurn;
            _gameClient.PlayerPassedPlace += GameClientOnPlayerPassedPlace;
            _gameClient.PlayerSetPlace += GameClientOnPlayerSetPlace;
            _gameClient.NextRound += GameClientOnNextRound;
        }

        public void SetGameView(IGameView gameView)
        {
            _gameView = gameView;
            _gameView.Loaded += GameViewOnLoaded;
            _gameView.SetPlayerController(_playerController);
        }

        private void GameViewOnLoaded()
        {
            _gameViewLoaded = true;

            if (_players.Any())
                _gameView.ReloadAllPlayers();

            foreach (var message in _preGameLoadServerMessages)
                _gameView.ChatServerMessage(message);

            _gameView.NextRound();
        }

        public Dictionary<int, IPlayerData> GetPlayers()
        {
            return _players;
        }

        public IPlayerData GetPlayerById(int playerId)
        {
            if (!_players.ContainsKey(playerId))
                return null;

            return _players[playerId];
        }

        public int GetCurrentPlayerId()
        {
            return _currentPlayerId;
        }

        public bool GetCurrentPlayerRolledThisTurn()
        {
            return _currentPlayerRolledThisTurn;
        }

        private void PlayerControllerOnGameActionException(string message)
        {
            _gameView.ShowGameActionException(message);
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

        private void GameClientOnChatServerMessage(VsadilNestihlNetworking.Messages.Chat.ChatServerMessage chatServerMessage)
        {
            if (!_gameViewLoaded)
            {
                _preGameLoadServerMessages.Add(chatServerMessage.Message);
                return;
            }

            _gameView.ChatServerMessage(chatServerMessage.Message);
        }

        private void GameClientOnChatPlayerMessage(VsadilNestihlNetworking.Messages.Chat.ChatPlayerMessage chatPlayerMessage)
        {
            _gameView.ChatPlayerMessage(chatPlayerMessage.PlayerId, chatPlayerMessage.Message);
        }

        private void GameClientOnPlayerSetMoney(PlayerSetMoney playerSetMoney)
        {
            _players[playerSetMoney.PlayerId].Money = playerSetMoney.Money;
        }

        private void GameClientOnPlayerRolledDice(PlayerRolledDice playerRolledDice)
        {
            _gameView.PlayerRolledDice(playerRolledDice.PlayerId, playerRolledDice.RolledCount);
        }

        private void GameClientOnPlayerRolledThisTurn(PlayerRolledThisTurn playerRolledThisTurn)
        {
            if (playerRolledThisTurn.PlayerId == _currentPlayerId)
                _currentPlayerRolledThisTurn = playerRolledThisTurn.RolledThisTurn;
        }

        private void GameClientOnPlayerPassedPlace(PlayerPassedPlace playerPassedPlace)
        {
            _gameView.PlayerPassedPlace(playerPassedPlace.PlayerId, playerPassedPlace.PlaceId);
        }
        private void GameClientOnPlayerSetPlace(PlayerSetPlace playerSetPlace)
        {
            _players[playerSetPlace.PlayerId].Place = new Place((ConcretePlace)playerSetPlace.PlaceId, "");
            _gameView.PlayerSetPlace(playerSetPlace.PlayerId, playerSetPlace.PlaceId);
        }

        private void GameClientOnNextRound(NextRound nextRound)
        {
            _currentPlayerId = nextRound.PlayerId;
            _gameView?.NextRound();
        }
    }
}
