﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VsadilNestihl.Game.Board;
using VsadilNestihl.Game.Player;
using VsadilNestihl.Game.PlayerControllers;

namespace VsadilNestihl.Game
{
    public class LocalGame : IGameUpdater, IGameData
    {
        private IPlayerController _playerController;
        private readonly int _myPlayerId;
        private IGameView _gameView;
        private bool _gameViewLoaded = false;
        
        private readonly Dictionary<int, IPlayerData> _players = new Dictionary<int, IPlayerData>();
        private int _currentPlayerId;
        private bool _currentPlayerRolledThisTurn;

        public LocalGame(int myPlayerId)
        {
            _myPlayerId = myPlayerId;
        }

        public void SetPlayerController(LocalPlayerController playerController)
        {
            _playerController = playerController;
            playerController.GameActionException += OnGameActionException;
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
        }

        public Dictionary<int, IPlayerData> GetPlayers()
        {
            return _players;
        }

        public IPlayerData GetPlayerById(int playerId)
        {
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

        public void OnGameActionException(string message)
        {
            _gameView.ShowGameActionException(message);
        }

        public void GameStarted(List<Player.Player> players)
        {
            foreach (var player in players)
            {
                var playerData = PlayerData.FromPlayer(player);
                _players.Add(playerData.PlayerId, playerData);

                /*var localPlayerController = new LocalPlayerController(player);
                PlayerControllers.Add(playerData.PlayerId, localPlayerController);*/
            }

            if (_gameViewLoaded)
                _gameView.ReloadAllPlayers();
        }

        public void PlayerSetMoney(Player.Player player, int money)
        {
            _players[player.PlayerId].Money = money;
        }

        public void PlayerRolledDice(Player.Player player, int rolledCount)
        {
            _gameView.PlayerRolledDice(player.PlayerId, rolledCount);
        }

        public void PlayerRolledThisTurn(Player.Player player, bool rolledThisTurn)
        {
            if (player.PlayerId == _currentPlayerId)
                _currentPlayerRolledThisTurn = rolledThisTurn;
        }

        public void PlayerSetPlace(Player.Player player, IPlace place)
        {
            _players[player.PlayerId].Place = place;
            _gameView.UpdatePlayerPlace(player.PlayerId);
        }

        public void NextRound(Player.Player currentPlayer)
        {
            _currentPlayerId = currentPlayer.PlayerId;
            _gameView?.NextRound();
        }
    }
}